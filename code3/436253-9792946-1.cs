    DataTable dt = new DataTable();
    dt.Columns.Add("col1");
    dt.Columns.Add("col2");
    dt.Columns.Add("col3");
    dt.Rows.Add(new object[] { "a", "b", "c" });
    dt.Rows.Add(new object[] { "d", "e", "f" });
    StringBuilder sb = new StringBuilder();
    sb.AppendLine("<html><body>");
    sb.Append("<table>");
    // headers.
    sb.Append("<tr>");
    foreach (DataColumn dc in dt.Columns)
    {
        sb.AppendFormat("<td>{0}</td>", dc.ColumnName);
    }
    sb.Append("</tr>");
    // data rows
    foreach (DataRow dr in dt.Rows)
    {
        sb.Append("<tr>");
        foreach (DataColumn dc in dt.Columns)
        {
            string cellValue = dr[dc] != null ? dr[dc].ToString() : "";
            sb.AppendFormat("<td>{0}</td>", cellValue);
        }
        sb.Append("</tr>");
    }
    sb.Append("</table>");
    sb.AppendLine("</body></html>");
