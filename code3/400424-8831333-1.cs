    var groups = dbRecipes.GroupBy(r => r.Group).OrderBy(g => g.GroupOrder);
    foreach(var recipeGroup in groups)
    {
        output.Write("{0}<br/>", recipeGroup.Key.GroupName);
        foreach(var recipe in recipeGroup.OrderBy(r => r.DisplayOrder))
        {
            output.Write("---{0}<br/>", r.Title);
        }
    }
