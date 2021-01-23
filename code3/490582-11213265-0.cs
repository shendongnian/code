    string filter = "10";
    DataSet Datos = new DataSet();
    string connectionString = "<your connection string here>";
    string selectCommand = 
      "SELECT * FROM myTable WHERE Id = " + filter;
    using (var MyConnection = new SqlConnection(connectionString))
    using (var MyDataAdapter = new SqlDataAdapter(selectCommand, MyConnection))
    {
       MyDataAdapter.SelectCommand.CommandType = CommandType.Text;
       MyDataAdapter.Fill(Datos);
    }
