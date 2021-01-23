    // Definition
    DataTable table = new DataTable();
    
    DataColumn column = new DataColumn("Parent", typeof(string));
    table.Columns.Add(column);
 
    // Data
    DataRow row = table.NewRow();
    row["Parent"] = "A";
    table.Rows.Add(row);
