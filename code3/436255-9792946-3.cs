    DataTable dt = new DataTable();
    dt.Columns.Add("col1");
    dt.Columns.Add("col2");
    dt.Columns.Add("col3");
    dt.Rows.Add(new object[] { "a", "b", "c" });
    dt.Rows.Add(new object[] { "d", "e", "f" });
    string tab = "\t";
    StringBuilder sb = new StringBuilder();
    sb.AppendLine("<html>");
    sb.AppendLine(tab + "<body>");
    sb.AppendLine(tab + tab + "<table>");
    // headers.
    sb.Append(tab + tab + tab + "<tr>");
    foreach (DataColumn dc in dt.Columns)
    {        
        sb.AppendFormat("<td>{0}</td>", dc.ColumnName);        
    }
    sb.AppendLine("</tr>");
    // data rows
    foreach (DataRow dr in dt.Rows)
    {
        sb.Append(tab + tab + tab + "<tr>");
        foreach (DataColumn dc in dt.Columns)
        {
            string cellValue = dr[dc] != null ? dr[dc].ToString() : "";
            sb.AppendFormat("<td>{0}</td>", cellValue);
        }
        sb.AppendLine("</tr>");
    }
    sb.AppendLine(tab + tab + "</table>");
    sb.AppendLine(tab + "</body>");
    sb.AppendLine("</html>");
