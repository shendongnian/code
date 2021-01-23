    var FullDatabaseItem = db.tblReviews.Include(g => g.tblGame);
    if (!string.IsNullOrEmpty(DisplaySearchResults))
    {
        FullDatabaseItem = FullDatabaseItem
            .Where(review => review.tblGame.GameName.Contains(DisplaySearchResults));
    }
