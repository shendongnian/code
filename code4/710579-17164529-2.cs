    [Test]
    public void StructureMapGetInstance_Pizza_ReturnsTwoIngredients()
    {
        StructureMap.IContainer structureMap = ConfigureStructureMap();
        var pizza = structureMap.GetInstance<IRecipe<Pizza>>();
        Assert.That(pizza.Ingredients.Count, Is.EqualTo(2));
    }
    [Test]
    public void StructureMapGetInstance_Omlette_ReturnsThreeIngredients()
    {
        StructureMap.IContainer structureMap = ConfigureStructureMap();
        var omlette = structureMap.GetInstance<IRecipe<Omlette>>();
        Assert.That(omlette.Ingredients.Count, Is.EqualTo(3));
    }
