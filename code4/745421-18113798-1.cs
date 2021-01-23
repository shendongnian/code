    materialTable = new DataTable();
    materialTable.Columns.Add("Material", typeof(string));
    DataRow row = materialTable.NewRow();
    row[0] = "First item";
    materialTable.Rows.Add(row);
    
