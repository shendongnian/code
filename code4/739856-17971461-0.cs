    public IEnumerable GetGuids(int id)
    {    
      List<string> items = new List<string>;        
      using (SqlCommand _command = new SqlCommand("StoredProc"))
      {
          _command.Connection = new SqlConnection(conString);
          _command.Connection.Open();
          _command.CommandType = CommandType.StoredProcedure;
          _command.Parameters.AddWithValue("@ItemID", id);
          using (var reader = _command.ExecuteReader())
          {
             while (reader.Read())
             {
                items.Add(reader[2]);
             }
          }        
      }
      return items;
    }
