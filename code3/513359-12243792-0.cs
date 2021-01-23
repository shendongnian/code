    NpgsqlDataAdapter npDataAdapterSingle = new NpgsqlDataAdapter("SELECT * from \"Weight\" ORDER BY id DESC LIMIT 1", this.npConnection);
    DataTable tmpTable = new DataTable("tmpTable");
    npDataAdapterSingle.Fill(tmpTable);
    
    row =  tmpTable.NewRow();
    
    foreach (DataColumn col in tmpTable.Columns)
       row[col.ColumnName] = tmpTable.Rows[0][col.ColumnName];
    
    tmpTable.Rows.Add(row, 0);
