    public static IEnumerable<DdlOption> ToDdlOption<T>(this IEnumerable<T> genericList, string strPropName)
    {
        return genericList.Select(l => new DdlOption
            {
                Id = l.Id,
                DisplayName = l.strPropName
            });
    }
