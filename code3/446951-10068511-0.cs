    public News GetLatestNews(Category cat)
    {
        var session = SessionFactory.CurrentSession;
        var news = session.CreateFilter(cat.LatestNews , "order by categoryorder").SetFirstResult((page - 1)  * pageSize).SetFirstResult(0).SetMaxResults(1).List().FirstOrDefault();
        return news;
    }
