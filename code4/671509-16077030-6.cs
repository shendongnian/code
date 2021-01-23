    var viewFullRecipeGrouping =
    (
        from data in viewRecipeSummary
        group data by data.RecipeName
        into recipeGroup
        let fullIngredientGroups = recipeGroup.GroupBy(x => x.IngredientName)
        select new ViewFullRecipe()
            {
                RecipeName = recipeGroup.Key,
                RecipeIngredients =
                    (
                        from ingredientGroup in fullIngredientGroups
                        select
                            new GroupIngredient
                                {
                                    IngredientName = ingredientGroup.Key,
                                    UnitWeight = ingredientGroup.Average(r => r.UnitWeight),
                                    TotalWeight = ingredientGroup.Sum(r => r.TotalWeight)
                                }
                    ).ToList(),
    
                ViewGroupRecipes =
                    (
                        from recipeName in
                            viewRecipeSummary.GroupBy(x => x.IngredientName)
                                                .Where(g => fullIngredientGroups.Any(f => f.Key == g.Key))
                                                .SelectMany(g => g.Select(i => i.RecipeName))
                                                .Distinct()
                        select new GroupRecipe()
                            {
                                RecipeName = recipeName,
                                Ingredients =
                                    viewRecipeSummary.Where(v => v.RecipeName == recipeName)
                                                        .GroupBy(i => i.IngredientName)
                                                        .Select(
                                                            g => new GroupIngredient
                                                                {
                                                                    IngredientName = g.Key,
                                                                    UnitWeight = g.Sum(i => i.UnitWeight),
                                                                    TotalWeight = g.Average(i => i.TotalWeight)
                                                                }).ToList()
                            }
                    ).ToList()
            }).ToList();
