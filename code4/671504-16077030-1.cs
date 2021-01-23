    using System.Collections.Generic;
    using System.Linq;
    
    namespace TestLinq
    {
        class Program
        {
            static void Main(string[] args)
            {
                var viewRecipeSummary = new List<Recipe>
                    {
                        new Recipe
                            {
                                RecipeName = "1",
                                IngredientName = "A"
                            },
    
                        new Recipe
                            {
                                RecipeName = "1",
                                IngredientName = "B"
                            },
                        new Recipe
                            {
                                RecipeName = "1",
                                IngredientName = "C"
                            },
                        new Recipe
                            {
                                RecipeName = "3",
                                IngredientName = "A"
                            },
                        new Recipe
                            {
                                RecipeName = "3",
                                IngredientName = "Z"
                            }
    
                    };
    
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
                                ViewGroupRecipes =
                                    (
                                        from recipeName in
                                            viewRecipeSummary.GroupBy(x => x.IngredientName)
                                                             .Where(g => fullIngredientGroups.Any(f => f.Key == g.Key))
                                                             .SelectMany(g => g.Select(i => i.RecipeName))
                                                             .Distinct()
                                        select new ViewFullRecipe()
                                        {
                                            RecipeName = recipeName,
                                            RecipeIngredients =
                                                viewRecipeSummary.Where(v => v.RecipeName == recipeName)
                                                                 .Select(i => i.IngredientName)
                                                                 .Distinct()
                                                                 .Select(
                                                                     i => new GroupIngredient
                                                                     {
                                                                         IngredientName = i
                                                                     })
                                        }
                                    ).ToList()
                            }).ToList();
            }
        }
    
        internal class GroupIngredient
        {
            public string IngredientName { get; set; }
        }
    
        internal class ViewFullRecipe
        {
            public string RecipeName { get; set; }
            public object RecipeIngredients { get; set; }
    
            public object ViewGroupRecipes { get; set; }
        }
    
        internal class Recipe
        {
            public string RecipeName { get; set; }
            public string IngredientName { get; set; }
        }
    }
