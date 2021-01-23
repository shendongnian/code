    public class CommandQueue
    {
        private Connection _connexion = new Connection(); // Set this up somehow.
    
        // Other methods to handle the concurrency/ calling/ transaction etc.
        public Func<string, Dictionary<string, int>, bool> CallStoredProcedure = (procedureName, parameterValueMap) =>
        {
          cmd.Connection = GetConnexion();
          var cmd = new SqlCommand(procedureName);
          cmd.CommandType = CommandType.StoredProcedure;
    
          foreach (var parameterValueMapping in parameterValueMap)
          {
            cmd.Parameters.Add(parameterValueMapping.Key, parameterValueMapping.Value);
          }
    
          var success = cmd.ExecuteNonQuery();
    
          return success;
        }
    
        private Connection GetConnexion()
        {
          return _connexion;
        }
    }
