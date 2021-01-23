    var table = new DataTable();
    
    table.Columns.Add("Id", typeof(int))
    table.Columns.Add("Contact", typeof(string))
    table.Columns.Add("Address", typeof(string))
    foreach(var entity in entities) {
        var row = table.NewRow();
        row["Id"] = entity.Id;
        row["Contact"] = entity.Contact.Name;
        row["Address"] = entity.Address.Address;
        table.Rows.Add(row);
    }
