    DbCommand command = null;
    if (connection is SqlConnection)
       command = new SqlCommand();
    else if (connection is OleDbConnection)
       command = new OleDbCommand();
    command.CommandText = "INSERT STATEMENT HERE";
    command.Connection = connection;
    command.ExecuteNonQuery();
