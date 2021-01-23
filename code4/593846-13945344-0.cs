    public static IEnumerable<DdlOption> ToDdlOptions<T>(this IEnumerable<T> genericList, string strPropName)
    {
        return genericList.Select(l => new DdlOption
            {
                Id = l.Id,
                DisplayName = l.strPropName
            });
    }
