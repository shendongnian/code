    static string GetDBPath(SqlConnection myConn, string db = "master")
    {
      string sqlstr = "USE " + db + "; EXEC sp_helpfile";
      SqlCommand command = new SqlCommand(sqlstr, myConn);
      SqlDataReader reader = command.ExecuteReader(CommandBehavior.SingleRow);
      reader.Read();
      string filename = reader["filename"].ToString();
      string directory = System.IO.Path.GetDirectoryName(filename);
      return directory;
    }
