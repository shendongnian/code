    OpenConnection2();
    command.Connection = connection;
    
    command.CommandText = query2;
    int c = command.ExecuteNonQuery();
    
    command.CommandText = query3;
    c = command.ExecuteNonQuery();
    
    command.CommandText = query4;
    c = command.ExecuteNonQuery();
    connection.Close();
