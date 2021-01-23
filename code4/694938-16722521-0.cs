    DataTable dt = new DataTable("MyNewTable");
    dt.Load(reader);
    foreach (DataRow row in dt.Rows)
    {
        foreach (DataColumn dc in row.Columns)
        {
            if (!String.IsNullOrEmpty(sb.ToString()))
                sb.Append(",");
            sb.Append(row[dc.ColumnName].ToString());
        }
        sb.Append("\n");
    }
