    DataTable dtTables = conn.GetSchema("Tables");
    SortedDictionary<string, DataRow> dcSortedTables = new SortedDictionary<string, DataRow>();
    foreach (DataRow table in dtTables.Rows) {
        string tableName = (string)table[2];
        dcSortedTables.Add(tableName, table);
    }
    // Loop through tables
    foreach (DataRow table in dcSortedTables.Values) {
        // your stuff here
    }
