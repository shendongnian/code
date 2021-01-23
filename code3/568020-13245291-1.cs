    protected void Button1_Click(object sender, EventArgs e)
    {
        var dataTable = GetData();
        StringBuilder builder = new StringBuilder();
        List<string> columnNames = new List<string>();
        List<string> rows = new List<string>();
        foreach (DataColumn column in dataTable.Columns)
        {
            columnNames.Add(column.ColumnName); 
        }
        builder.Append(string.Join(",", columnNames.ToArray())).Append("\n");
        foreach (DataRow row in dataTable.Rows)
        {
            List<string> currentRow = new List<string>();
            foreach (DataColumn column in dataTable.Columns)
            {
                object item = row[column];
                currentRow.Add(item.ToString());
            }
            rows.Add(string.Join(",", currentRow.ToArray()));
        }
        builder.Append(string.Join("\n", rows.ToArray()));
        Response.Clear();
        Response.ContentType = "text/csv";
        Response.AddHeader("Content-Disposition", "attachment;filename=myfilename.csv");
        Response.Write(builder.ToString());
        Response.End();
    }
