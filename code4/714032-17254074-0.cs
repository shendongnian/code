    public static string ToTraceString<T>(this IQueryable<T> query)
    {
        var objQuery = query as ObjectQuery<T>;
        if (objQuery != null)
        {
            return string.Format("{0}{2}{1}{2}{2}", DateTime.Now, objQuery.ToTraceString(), Environment.NewLine);
            
        }
        return string.Empty;
    }
