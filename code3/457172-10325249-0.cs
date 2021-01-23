    class Recipe {
        public IEnumerable<IIngredient> Ingredients { get; set; }
    
    }
    
    class UsefulRecipe : Recipe, IIngredient
    {
        void DoIngredientStuff()
        {
            // not all Recipes are ingredients - this might be an illegal call
        }
    }
