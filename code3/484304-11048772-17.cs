    public static string ToCsv(DataTable table, string separator = null)
    {
        if (separator == null)
            separator = CultureInfo.CurrentCulture.TextInfo.ListSeparator;
        return table.Rows
            .Cast<DataRow>()
            .Select(r => String.Join(separator, r.ItemArray.Select(c => FormatValue(c)))
            .Aggregate(new StringBuilder(), (result, line) => result.AppendLine(line))
            .ToString();
    }
    
