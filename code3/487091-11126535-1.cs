    public static string GetMyTable<T>(IEnumerable<T> list, params Func<T, object>[] columns)
    {
        var sb = new StringBuilder();
        foreach (var item in list)
        {
            //todo this should actually make an HTML table, not just get the properties requested
            foreach (var column in columns)
                sb.Append(column(item));
        }
        return sb.ToString();
    }
    //used like
    string HTML = GetMyTable(people, x => x.FirstName, x => x.LastName);
