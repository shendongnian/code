    var thresholdDate = db.Articles.Single(a => a.Id == 100).PublicationDate;
    var articles = 
        db.Articles
        .Where(a => a.PublicationDate <= thresholdDate)
        .OrderByDescending(a => a.PublicationDate)
        .Take(20);
