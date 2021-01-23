    public IList<Articles> GetArticles()
    {
        try
        {
            return GetSomeArticlesFromDatabase();
        }
        catch (Exception innerException)
        {
            throw new MyCustomException("some data", 500, innerException);
        }
    }
