    using (OracleConnection connection = new OracleConnection(<VALID CONN STRING GOES HERE>)) {
        connection.Open();
        using (OracleCommand command = new OracleCommand()) {
             command.Connection = connection;
             command.CommandText = "UPDATE testing SET COMMENTS = :COMMENTS, DATEMODIFIED = sysdate WHERE ID = :ID";
             command.CommandType = CommandType.Text;
             command.Parameters.Add("COMMENTS", OracleDbType.Clob, ParameterDirection.Input).Value = comments.Text;
             command.Parameters.Add("ID", OracleDbType.Int32, ParameterDirection.Input).Value = 1;
             command.ExecuteNonQuery();
        }
    }
