    public void SetIngredientsForRecipe(long recipeId, List<string> ingredients)
    {
      using (var db = new FoodEntities(ConnectionString, null, null))
      {    
        var recipe = db.recipe.Single(r => r.ID == recipeId);
        // clear all ingredients first
        recipe.ingredients.Clear()
            
        var ingrArr = ingredients.ToArray();
        var ingrIds = new HasSet<int>(db.ingrediants
          .Where(i => ingrArr.Contains(i.Name))
          .Select(i => I.Id)); 
          
        foreach (var id in ingrIds)
        {
          // mock the ingredients rather than fetching them, for relations only the id needs to be there
          recipe.ingredients.Add(new Ingredient()
          {
            Id = id
          });
        }
        
        db.SaveChanges();
      }
    }
