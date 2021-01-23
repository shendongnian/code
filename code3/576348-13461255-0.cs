    using(IDataReader reader = GetName.ExecuteReader())
    {
      if (reader.Read())
      {
        // Populate any object using reader.GetString(reader.GetOrdinal("FieldName"))
        // Replace GetString for any data type you need.
      }
      else
      {
        // No rows returnes
      }
    }
