    using(OleDbConnection cn = OpenConnection2())
    using(OleDbCommand command = new OleDbCommand())
    {
        command.Connection = connection;
        command.CommandText = query2;
        int c = command.ExecuteNonQuery();
    
        command.CommandText = query3;
        c = command.ExecuteNonQuery();
    
        command.CommandText = query4;
        c = command.ExecuteNonQuery();
    } // here the connection will be closed and disposed 
