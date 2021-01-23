    public static IEnumerable<IQueryable<T>> Paginate<T>(
        this IQueryable<T> query, int pagesize)
    {
        int numPages = (int)Math.Ceiling(query.Count() / (double)pagesize);
        for (int i = 0; i < numPages; i++)
        {
            var page = query.Skip(i * pagesize)
                    .Take(pagesize);
            yield return page;
        }
    }
