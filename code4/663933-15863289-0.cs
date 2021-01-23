    var article = context.Articles.Find(1);
    context.Articles.Remove(article);
    var detailedArticle = new DetailedArticle
    {
        Id = article.Id,
        Name = article.Name,
        SerialNumber = "ABC"
    };
    context.Articles.Add(detailedArticle);
    context.SaveChanges();
