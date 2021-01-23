    public Func<string, Dictionary<string, int>, bool> CallStoredProcedure = (procedureName, parameterValueMap) =>
    {
      var cmd = new SqlCommand("procedureName");
      cmd.CommandType = CommandType.StoredProcedure;
      foreach (var parameterValueMapping in parameterValueMap)
      {
        cmd.Parameters.Add(parameterValueMapping.Key, parameterValueMapping.Value);
      }
      var success = cmd.ExecuteNonQuery();
      return success;
    }
