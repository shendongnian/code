    MySqlCommand command = new MySqlCommand();
    command.CommandText = "select * from nama;";
     
    MySqlDataReader reader = command.ExecuteReader();
    DataTable tblNama = new DataTable();
    tblNama.Load(reader);
    
    int numR = tblNama.Rows.Count; //Number of Rows ...
    int numC = tblNama.Columns.Count; //Number of Columns ...
