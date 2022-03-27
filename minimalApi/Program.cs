using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Description = "Teste com Minimal APIs", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
});



app.MapGet("/", (Func<object>)(() =>
{
    const string mensagem = "Exemplo de uso de Minimal APIs em ASP.NET Core";
    var horario = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
    Console.WriteLine($"[{horario}] Recebida requisição - {mensagem}");
    return new
    {
        Saudacao = "Bem-vindo ao .NET 6!",
        Descricao = mensagem,
        Horario = horario
    };
}));

app.Run();

