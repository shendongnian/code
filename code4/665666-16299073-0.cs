    using (SqlConnection AutoConn = new SqlConnection(cn))
    {
        AutoConn.Open();
        using (SqlCommand InfoCommand = new SqlCommand())
        {
            using (SqlDataAdapter infoAdapter = new SqlDataAdapter(InfoCommand))
            {
                InfoCommand.Connection = AutoConn;
                InfoCommand.CommandType = CommandType.StoredProcedure;
                InfoCommand.CommandText = "myDeleteQuery";
                InfoCommand.Parameters.AddWithValue("@paramID", myID);
                InfoCommand.CommandTimeout = 180;
                InfoCommand.ExecuteScalar()
                AutoConn.Close();
            }
        }
    }
