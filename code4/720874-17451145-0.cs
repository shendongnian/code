    public static IEnumerable<IEnumerable<T>> Paginate<T>(this IQueryable<T> query, int pagesize)
    {
        int pageNumber = 0;
        var page = query.Take(pagesize).ToList();
        while (page.Any())
        {
            yield return page;
            pageNumber++;
            page = query.Skip(pageNumber * pagesize)
                .Take(pagesize)
                .ToList();
        }
    }
