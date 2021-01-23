    public static IEnumerable<T> GetPage(this ICouchDatabase couchDatabase,
        string viewName,
        string designDoc,
        int page,
        int pageSize)
    {   
        return couchDatabase.View(viewName, new ViewOptions
        {
            Skip = page * pageSize,
            Limit = pageSize
        }, designDoc);
    }
