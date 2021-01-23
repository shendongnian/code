    private static IList<T> GetObjectList(DateTime mostRecentProcessedReadTime)
    {
        using (var data = RepositoryFactory.CreateRepository<T>())
        {
            return data.Get(mostRecentProcessedReadTime);
        }
    }
