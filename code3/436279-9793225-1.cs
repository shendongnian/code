    private string ConvertToHtml(DataTable dataTable)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<table>");
        if (dataTable != null)
        {
            sb.Append("<tr>");
            foreach (DataColumn column in dataTable.Columns)
                sb.AppendFormat("<td>{0}</td>", HttpUtility.HtmlEncode(column.ColumnName));
            sb.Append("</tr>");
            foreach (DataRow row in dataTable.Rows)
            {
                sb.Append("<tr>");
                foreach (DataColumn column in dataTable.Columns)
                    sb.AppendFormat("<td>{0}</td>", HttpUtility.HtmlEncode(row[column]));
                sb.Append("</tr>");
            }
        }
        sb.Append("</table>");
        return sb.ToString();
    }
