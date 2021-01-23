    DbTables = connection.GetSchema("Tables");
    var rowsToBeRemoved = new List<DataRow>();
    
    foreach (DataRow row in DbTables.Rows)
    {
        Console.WriteLine(row[3].ToString());
    
        if (row[3].ToString() == "SYSTEM_TABLE")
           rowsToBeRemoved.Add(row);
    }
    
    foreach DataRow row in rowsToBeRemoved)
    {
        DbTables.Rows.Remove(row);
    }
