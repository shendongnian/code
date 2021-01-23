    string connectionString = @"Provider=PCSOFT.HFSQL;Initial Catalog=C:\MyDataFolder";
    string sql = @"SELECT * FROM MyTable"; //MyTable = The .FIC file
    DataTable table = new DataTable();
    using (OleDbConnection connection = new OleDbConnection(connectionString))
    {
           using (OleDbDataAdapter adapter = new OleDbDataAdapter(sql, connection))
           {
                  adapter.Fill(table); //Fill the table with the extracted data
           }
    }
                
    gridControl1.DataSource = table; //Set the DataSource of my grid control
