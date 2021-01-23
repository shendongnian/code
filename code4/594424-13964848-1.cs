    EntityCommand command = connection.CreateCommand();
    command.CommandText = "XXXX";
    command.CommandType = CommandType.StoredProcedure;
                            
    using (EntityDataReader reader = command.ExecuteReader(CommandBehavior.SequentialAccess))
    {
        while (reader.Read())
        {
              str = str + reader.GetString(0);
        }
    }
