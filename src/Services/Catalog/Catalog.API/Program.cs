var builder = WebApplication.CreateBuilder(args);

//Add Services to the container.
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
})
    .UseLightweightSessions();

var app = builder.Build();

//configure the HTTP request pipeline.
app.MapCarter();

app.Run();
