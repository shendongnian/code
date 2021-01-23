    Article article; // from post action parameters
    IEnumerable<int> categoryIds; // from post action parameters
    using (var ctx = new MyDbContext())
    {
        foreach (var categoryId in categoryIds)
        {
            var category = new Category { CategoryId = categoryId };
            ctx.Categories.Attach(category); // this avoids duplicate categories
            article.Categories.Add(category);
            // I assume here that article.Categories was empty before
        }
        ctx.Articles.Add(article);
        ctx.SaveChanges();
    }
