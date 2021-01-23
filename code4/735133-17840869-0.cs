    public bool Update(Recipe recipe)
    {
        if (recipe.TagList != null)
            AssignTags(recipe, recipe.TagList);
    
         Recipe dbEnt = context.Recipes.Find(recipe.RecipeId);
         if (context.Entry(dbEnt).State == EntityState.Detached)
         {
             context.Set<Recipe>().Attach(dbEnt);
         }
         context.Entry(dbEnt).State = EntityState.Modified;
         context.Entry(dbEnt).CurrentValues.SetValues(recipe);
    
         return Save();
    }
