        using (var connection = new System.Data.SqlClient.SqlConnection("ConnectionString"))
        {
            connection.Open();
            var command = new System.Data.SqlClient.SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
            command.CommandText = "SELECT name FROM master.sys.databases";
            var adapter = new System.Data.SqlClient.SqlDataAdapter(command);
            var dataset = new DataSet();
            adapter.Fill(dataset);
            DataTable dtDatabases = dataset.Tables[0];
        }
