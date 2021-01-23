    string sqlCmd = "SELECT * from dbo.BarcodeWithLocation";
    using (SqlCommand command = new SqlCommand(sqlCmd, connection))
    {
         DataTable dataTable = new DataTable();
         command.CommandType = System.Data.CommandType.Text;
         connection.Open();
         SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
         dataAdapter.Fill(dataTable);
         Grid.DataSource = dataTable;
         Grid.DataBind();
    }
