    public List<Article> GetArticles()
    {
        List<Article> model;
        using (var context = new MyEntities())
        {
            //for an example I've assumed your "MyTable" is a table of news articles
            model = (from mt in context.Articles
                    select mt).ToList();
            //data in a List<T> so the database has been hit now and data is final
        }
    
        return model;
    }
