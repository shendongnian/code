    public static void PrintColumnHeaders(NWRevalDatabaseEntities entities, string tableName)
    {
        var sc = ((System.Data.EntityClient.EntityConnection)entities.Connection).StoreConnection;
        System.Data.SQLite.SQLiteConnection sqliteConnection = (System.Data.SQLite.SQLiteConnection)sc;
        sqliteConnection.Open();
        System.Data.Common.DbCommand cmd = sc.CreateCommand();
        cmd.CommandType = System.Data.CommandType.Text;
        cmd.CommandText = string.Format("PRAGMA table_info('{0}');", tableName);
        System.Data.Common.DbDataReader reader = cmd.ExecuteReader();
        if (reader.HasRows)
        {
            object[] values = new object[reader.FieldCount];
            while (reader.Read())
            {
                int result = reader.GetValues(values);
                string columnHeader = (string)values[1]; // table_info returns a row for each column, with the column header in the second column.
                Console.WriteLine("Column Header: {0}", columnHeader);
            }
        }
        sqliteConnection.Close();
    } 
