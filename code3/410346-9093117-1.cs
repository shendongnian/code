        public ActionResult ShowMyRecipes()
        {
            var myRecipes = dbContext.Recipes.Where(recipe => recipe.Author.Equals(User.Identity.Name)).ToList();
            return View(myRecipes);
        }
