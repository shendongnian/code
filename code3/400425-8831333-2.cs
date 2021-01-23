    var groups = dbRecipes.GroupBy(r => r.Group).OrderBy(g => g.Key.GroupOrder);
    foreach(var recipeGroup in groups)
    {
        output.Write("{0}<br/>", recipeGroup.Key.GroupName);
        foreach(var recipe in recipeGroup.OrderBy(r => r.DisplayOrder))
        {
            output.Write("---{0}<br/>", recipe.Recipe.Title);
        }
    }
