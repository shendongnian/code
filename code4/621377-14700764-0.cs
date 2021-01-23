    public static string GetStringSeperatedBy(this DataTable dt, string delimiter)
    {
        var sb = new StringBuilder();
        var columnNames = dt.Columns.Cast<DataColumn>().Select(column => string.Format("\"{0}\"", column.ColumnName)).ToArray();
        sb.AppendLine(string.Join(delimiter, columnNames));
        foreach (DataRow row in dt.Rows)
        {
           var fields = row.ItemArray.Select(field => string.Format("\"{0}\"", field.ToString().Replace(Environment.NewLine, " ").Replace("\"", ""))).ToArray();
                sb.AppendLine(string.Join(delimiter, fields));
        }
        return sb.ToString();
     }
