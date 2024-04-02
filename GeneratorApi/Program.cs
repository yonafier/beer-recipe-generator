var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var beerRecipes = new List<BeerRecipe>()
{ 
    new ("IPA", "A hoppy beer", "IPA", "Ale", "Hops, Malt, Yeast", "Instructions"),
    new ("Stout", "A dark beer", "Stout", "Ale", "Hops, Malt, Yeast", "Instructions"),
    new ("Pilsner", "A light beer", "Pilsner", "Lager", "Hops, Malt, Yeast", "Instructions"),
    new ("Porter", "A dark beer", "Porter", "Ale", "Hops, Malt, Yeast", "Instructions"),
    new ("Saison", "A spicy beer", "Saison", "Ale", "Hops, Malt, Yeast", "Instructions"),
    new ("Wheat", "A wheat beer", "Wheat", "Ale", "Hops, Malt, Yeast", "Instructions"),
    new ("Lager", "A light beer", "Lager", "Lager", "Hops, Malt, Yeast", "Instructions"),
    new ("Sour", "A sour beer", "Sour", "Ale", "Hops, Malt, Yeast", "Instructions"),
    new ("Barleywine", "A strong beer", "Barleywine", "Ale", "Hops, Malt, Yeast", "Instructions"),
    new ("Amber", "An amber beer", "Amber", "Ale", "Hops, Malt, Yeast", "Instructions"),
    new ("Blonde", "A blonde beer", "Blonde", "Ale", "Hops, Malt, Yeast", "Instructions"),
    new ("Brown", "A brown beer", "Brown", "Ale", "Hops, Malt, Yeast", "Instructions"),
    new ("Cream", "A cream beer", "Cream", "Ale", "Hops, Malt, Yeast", "Instructions"),
    new ("Pale Ale", "A pale ale", "Pale Ale", "Ale", "Hops, Malt, Yeast", "Instructions"),
    new ("Red Ale", "A red ale", "Red Ale", "Ale", "Hops, Malt, Yeast", "Instructions")
};

var random = new Random();

app.MapGet("/beer/recipes/generate", () =>
    {
        int index = random.Next(beerRecipes.Count);
        return beerRecipes[index];
    })
    .WithOpenApi();

app.Run();

record BeerRecipe(string Name, string Description, string Style, string Type, string Ingredients, string Instructions);