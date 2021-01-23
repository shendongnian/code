    internal int GetCharGuidByName(string charactername, MySqlConnection connection)
    {
        int charguid = 0;
    
        using(MySqlCommand command = connection.CreateCommand())
        {
          command.CommandText = "SELECT guid FROM characters WHERE name=\""+charactername+"\";";
          object obj  = command.ExecuteScalar();
          if (obj != null && obj != DBNull.Value)
          {
             charguid = Convert.ToInt32(obj);
          }
        }
    
          return charguid;
    }
