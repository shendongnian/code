    var query1 = db.CtArticleDetail
        .Where(a => a.tagNames.Equals(tagNames))
        .Select(a => new NewsFilterModel() { ArticleDetail = a, Page = null });
    var query2 = db.PcPage
        .Where(a => a.tagNames.Equals(tagNames))
        .Select(a => new NewsFilterModel() { ArticleDetail = null, Page = a });
    var query3 = query1.Union(query2)
        //.OrderBy(a => a.Date); -- Order here
        ;
