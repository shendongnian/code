    public static IEnumerable<T> Paginate<T>(this IQueryable<T> query, int pageSize)
    {
        return GetPages(query, pageSize).SelectMany(x => x);
    }
    public static IEnumerable<IEnumerable<T>> GetPages<T>(this IQueryable<T> query, int pageSize)
    {
        for (int currentPage = 0; true; currentPage++)
        {
            IEnumerable<T> nextPage = query.Skip(currentPage * pageSize)
                .Take(pageSize)
                .ToList();
            if (nextPage.Any())
                yield return nextPage;
            else
                yield break;
        }
    }
