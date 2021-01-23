    public static string GetMyTable(IEnumerable list, params string[] columns)
    {
        var sb = new StringBuilder();
        foreach (var item in list)
        {
            //todo this should actually make an HTML table, not just get the properties requested
            foreach (var column in columns)
                sb.Append(item.GetType().GetProperty(column).GetValue(item, null));
        }
        return sb.ToString();
    }
    //used like
    string HTML = GetMyTable(people, "FirstName", "LastName");
