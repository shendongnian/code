    var articles = 
        db.Articles
        .Where(a => a.PublicationDate 
                 <= db.Articles.Single(aa => aa.Id == 100).PublicationDate)
        .OrderByDescending(a => a.PublicationDate)
        .Take(20);
