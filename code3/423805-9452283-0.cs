    string sql = "SELECT ProfilCode, ProfilName FROM Profils";
    DataTable myTable = new DataTable();
    
    using(MySqlConnection connection = new MySqlConnection(connectionString))
    {
       using(MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection))
       {
          adapter.Fill(myTable);
       }
    }
    
    dataGridView.DataSource = myDataTable;
