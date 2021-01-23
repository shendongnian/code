    public IQueryable<News> FindNews(int? page)
    {
        IQueryable<News> news = db.News.OrderByDescending(n => n.PublishDate);
    
        if (page != null)
           news = news.Skip(page.Value * 5);
    
        return news.Take(5);
    }
