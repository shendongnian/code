    public List<Guid> GetAllIds()
    {
        var cmd = new SqlCommand(yourConnectionString, "SELECT yourIDColumn from YourTable")
        
        var ids = new List<GUID>();
        Using(var reader = cmd.ExecuteReader())
        {
          while (reader.Read())
          {
            ids.Add(reader.GetGuid(0))
          }
        }
      return ids;
    }
