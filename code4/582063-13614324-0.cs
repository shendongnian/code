      string connect = System.Configuration.ConfigurationManager.AppSettings["conn"];
      SqlConnection connection = new SqlConnection(connect);
      string spName = "TheSpName";
      SqlCommand spCmd = new SqlCommand(spName, connection);
      spCmd.CommandType = CommandType.StoredProcedure;
      spCmd.Parameters.Add("@SomeParam", SqlDbType.String).Value = "Some Parameter";
      
      connection.Open();
      var dataTableReader = spCmd.ExecuteReader();
