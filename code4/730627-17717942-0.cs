    DB = new SQLiteConnection(@"Data Source="+DBFileName);
    DB.Open();
    SQLiteCommand command = new SQLiteCommand("PRAGMA table_info('tracks')", DB);
    DataTable dataTable = new DataTable();
    SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
    dataAdapter.Fill(dataTable);
    DB.Close();
    foreach (DataRow row in dataTable.Rows) { 
        DBColumnNames.Add((string)row[dataTable.Columns[1]]); }  
                //Out(String.Join(",", 
        DBColumnNames.ToArray()));//debug
