    NpgsqlCommand command = new NpgsqlCommand( "update battery set stock = :stock where id = :id;", connection);
    try
    {
     command.Parameters.Add(new NpgsqlParameter("stock", NpgsqlTypes.NpgsqlDbType.Integer));
     command.Parameters.Add(new NpgsqlParameter("id", NpgsqlTypes.NpgsqlDbType.Integer));
     command.Parameters[0].Value = stock;
     command.Parameters[1].Value = id;
    
     command.ExecuteNonQuery();
    
    command.
    }
    catch( NpgsqlException e )
    {
    ....
    }
