    
    public static bool StoredProcedureExists(this string source)
    {
      using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
      {
        conn.Open();
        using (var cmd = new SqlCommand($"select object_id('{source}')", conn))
          return !cmd.ExecuteScalar().ToString().IsNullOrWhiteSpace();
      }
    }
