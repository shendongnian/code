    var myDataTable = new DataTable();
    using (var conection = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;" + "data source=C:\\menus\\newmenus\\menu.mdb;Password=****"))
    {
         conection.Open();
         var query = "Select siteid From n_user";
         var command = new OleDbCommand(query, conection);
         var reader = command.ExecuteReader();
         while(reader.Read())
             textBox1.Text = reader[0].ToString();
     }
