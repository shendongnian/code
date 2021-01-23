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
                                IngredientName = ingredientGroup.Key
                            }
                    ).ToList(),
                IngredientQuantity = fullIngredientGroups.Count()
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
                                                    .Select(i => i.IngredientName)
                                                    .Distinct()
                                                    .Select(
                                                        i => new GroupIngredient
                                                        {
                                                            IngredientName = i
                                                        }).ToList(),
                          IngredientQuantity =
                                viewRecipeSummary.Where(v => v.RecipeName == recipeName)
                                                    .Select(i => i.IngredientName)
                                                    .Distinct()
                                                    .Count()
                        }
                    ).ToList()
            }).ToList();
