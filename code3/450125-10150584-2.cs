    string gameName = "Pac-Man";
    using (var db = new gamezoneDBEntities())
    {
        // get reviews for game named pac-man
        var reviews = db.tblReviews.Include(r => r.tblGame)
            .Where(r => r.tblGame.GameName.Equals(gameName, 
                StringComparison.OrdinalIgnoreCase));
    
        // get game with reviews scored greater than 4
        var games = db.tblGames.Include(g => g.tblReviews)
            .Where(g => g.tblReviews.Any(r => r.Score > 4));
    }
