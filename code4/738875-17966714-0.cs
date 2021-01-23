    var name = new DataColumn();
    name.DataType = typeof(string);
    name.ColumnName = "Name";
    
    var surName = new DataColumn();
    surName.DataType = typeof(string);
    surName.ColumnName = "surName";
    
    var concatName = new DataColumn();
    concatName.DataType = typeof(string);
    concatName.ColumnName = "concatName";
    
    var id = new DataColumn();
    id.DataType = typeof(int);
    id.ColumnName = "ID";
    
    var table = new DataTable("TableA");
    table.Columns.Add(name);
    table.Columns.Add(surName);
    table.Columns.Add(concatName);
    table.Columns.Add(id);
    
    foreach(var res in TableA.AsEnumerable())
    {
        var row = table.NewRow();
        row["name"] = res.Name;
        row["surName"] = res.surName;
        row["concatName"] = res.concatName;
        row["ID"] = res.ID;
        table.Rows.Add(row);
    }
    
