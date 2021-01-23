        public ActionResult ShowMyRecipes()
        {
            var myRecipes = dbContext.Recipes.Where(recipe => recipe.Author.Equals(User.Identity.Name)).ToList();
            return View(myRecipes);
        }
        public ActionResult CreateRecipe(Recipe recipe)
        {
            // set Author to curently logged in user's key
            recipe.Author = Membership.GetUser().ProviderUserKey;
            // save changes
            dbContext.Recipes.Add(recipe);
        }
