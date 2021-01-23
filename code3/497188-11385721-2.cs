    Article article; // from post action parameters
    IEnumerable<int> categoryIds; // from post action parameters
    using (var ctx = new MyDbContext())
    {
        // Load original article from DB including its current categories
        var articleInDb = ctx.Articles.Include(a => a.Categories)
            .Single(a => a.ArticleId == article.ArticleId);
        // Update scalar properties of the article
        ctx.Entry(articleInDb).CurrentValues.SetValues(article);
        // Remove categories that are not in the id list anymore
        foreach (var categoryInDb in articleInDb.Categories.ToList())
        {
            if (!categoryIds.Contains(categoryInDb.CategoryId))
                articleInDb.Categories.Remove(categoryInDb);
        }
        // Add categories that are not in the DB list but in id list
        foreach (var categoryId in categoryIds)
        {
            if (!articleInDb.Categories.Any(c => c.CategoryId == categoryId))
            {
                var category = new Category { CategoryId = categoryId };
                ctx.Categories.Attach(category); // this avoids duplicate categories
                articleInDb.Categories.Add(category);
            }
        }
        ctx.SaveChanges();
    }
