    public static IEnumerable<IQueryable<T>> Paginate<T>(
        this IQueryable<T> query, int pagesize)
    {
        //note that this is hitting the DB
        int numPages = (int)Math.Ceiling(query.Count() / (double)pagesize);
        for (int i = 0; i < numPages; i++)
        {
            var page = query.Skip(i * pagesize)
                    .Take(pagesize);
            yield return page;
        }
    }
