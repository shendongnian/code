    var query = new StringBuilder()
        .AppendLine("SELECT * FROM products")
        .AppendWhereIf(!String.IsNullOrEmpty(name), "name LIKE @name")
        .AppendWhereIf(category.HasValue, "category = @category")
        .AppendWhere("Deleted = @deleted")
        .ToString();
    var p_name = GetParameter("@name", name);
    var p_category = GetParameter("@category", category);
    var p_deleted = GetParameter("@deleted", false);
    var result = ExecuteDataTable(query, p_name, p_category, p_deleted);
    // in a seperate static class for extensionmethods
    public StringBuilder AppendLineIf(this StringBuilder sb, bool condition, string value)
    {
        if(condition)
            sb.AppendLine(value);
        return sb;
    }
    public StringBuilder AppendWhereIf(this StringBuilder sb, bool condition, string value)
    {
        if (condition)
            sb.AppendLineIf(condition, sb.HasWhere() ? " AND " : " WHERE " + value);
        return sb;
    }
    public StringBuilder AppendWhere(this StringBuilder sb, string value)
    {
        sb.AppendWhereIf(true, value);
        return sb;
    }
    public bool HasWhere(this StringBuilder sb)
    {
        var seperator = new string [] { Environment.NewLine };
        var lines = sb.ToString().Split(seperator, StringSplitOptions.None);
        return lines.Count > 0 && lines[lines.Count - 1].Contains("where", StringComparison.InvariantCultureIgnoreCase);
    }
    // http://stackoverflow.com/a/4217362/98491
    public static bool Contains(this string source, string toCheck, StringComparison comp)
    {
        return source.IndexOf(toCheck, comp) >= 0;
    }
