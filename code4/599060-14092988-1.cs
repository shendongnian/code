    public IEnumerable<TokenNews> GetNews(Guid tokenid)
    {
        var newslist = from news in entities.News
                       where news.TokenId == tokenid &&
                             DateTime.Now > news.Expiration &&
                             news.IsActive
                       orderby news.OrderNumber
                       select new TokenNews
                       {
                           Title = news.NewsTitle,
                           Body = news.NewsBody
                       };
        return newslist.ToArray();
    }
