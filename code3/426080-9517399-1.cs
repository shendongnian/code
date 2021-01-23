    public void SetIngredientsForRecipe(long recipeId, List<string> ingredients)
    {
       using (var db = new FoodEntities(ConnectionString, null, null))
       {
          // make an array since EF4 supports the contains keyword for arrays
          var ingrArr = ingredients.ToArray();
          // get the ids (and only the ids) of the new ingredients
          var ingrNew = new HasSet<int>(db.ingrediants
            .Where(i => ingrArr.Contains(i.Name))
            .Select(i => I.Id));   
    
          // get the ids (again only the ids) of the current ingredients
          var curIngr = new HasSet<int>(db.ingrediants
            .Where(r => r.Id == recipeId)
            .SelectMany(r => r.ingredients)
            .Select(i => I.Id));        
          // use the build in hash set functions to get the ingredients to add / remove            
          var toAdd = ingrNew.ExpectWith(curIngr);
          var toRemove = curIngr.ExpectWith(ingrNew);   
    
          foreach (var id in toAdd)
          {
            // mock the ingredients rather than fetching them, for relations only the id needs to be there
            recipe.ingredients.Add(new Ingredient()
            {
              Id = id
            });
          }
             
          foreach (var id in toRemove)
          {
            // again mock only
            recipe.ingredients.Remove(new Ingredient()
            {
              Id = id
            });
          }
          
          db.SaveChanges();
       }
    }
