    var queryString = "select * from Students where SID= " + U_ID, con;
    using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            OleDbCommand command = new OleDbCommand(queryString, connection);
            connection.Open();
            OleDbDataReader reader = command.ExecuteReader();
    
            while (reader.Read())
            {
                txtId.Text = reader["SID"].ToString();
            }
            reader.Close();
        }
