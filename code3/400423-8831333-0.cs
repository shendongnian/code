    var groups = dbRecipes.GroupBy(r => r.Group.GroupName);
    foreach(var recipeGroup in groups)
    {
        output.Write("{0}<br/>", recipeGroup.Key);
        foreach(var recipe in recipeGroup.OrderBy(r => r.DisplayOrder))
        {
            output.Write("---{0}<br/>", r.Title);
        }
    }
