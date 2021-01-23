    class Product : IIngredient
    {
    	void DoIngredientStuff();
    }
    class Recipe
    {
    	public IEnumerable<IIngredient> Ingredients { get; set; }
    }
    class IngredientRecipe : Recipe, IIngredient
    {
    	void DoIngredientStuff();
    }
