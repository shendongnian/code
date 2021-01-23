    [HttpPost]
    [Authorize]
    public JsonResult Rate(int Score, int IDRecipe)
    {
        //On valide si l'utilisateur a déja voté
        Guid userGuid = (Guid)Membership.GetUser().ProviderUserKey;
        var existingVote = db.StarRatings.Where(a => a.IDRecipe == IDRecipe).Where(b => b.IDUser == userGuid).FirstOrDefault();
        if (existingVote != null)
            return Json(false);
        StarRating rating = new StarRating();
        rating.IDRecipe = IDRecipe;
        rating.IDUser = (Guid)Membership.GetUser().ProviderUserKey;
        rating.Score = Score;
        var recipe = db.Recipes.Where(a => a.IDRecipe == IDRecipe).First();
        recipe.StarRatings.Add(Score);
        db.SaveChanges();
        return Json(true);
    }
