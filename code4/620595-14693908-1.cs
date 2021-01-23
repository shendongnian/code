    public static List<Article> Read()
    {
        using (uDataContext dbx = new uDataContext())
        {
            dbx.DeferredLoadingEnabled = false;
            return dbx.Article.ToList();
        }
    }
