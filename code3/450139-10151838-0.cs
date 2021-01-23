    var sql 0 "";
    using (var cnn = new SqlConnection(connection))
    {
      cnn.Open();
      sql = "CREATE DATABSE <databasename>";
      using (var cmd = new SqlCommand(sql, cnn))
      {
        try
        {
          cmd.CommandTimeout = 120;
          cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
          Console.WriteLine("Execution error!\n\n" + sql + "\n\n\n" + ex);
        }
      }
      sql = "USE DATABSE <databasename>;EXEC sp_dbchangeowner <Username>";
      using (var cmd = new SqlCommand(sql, cnn))
      {
        try
        {
          cmd.CommandTimeout = 120;
          cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
          Console.WriteLine("Execution error!\n\n" + sql + "\n\n\n" + ex);
        }
      }
      cnn.Close();
    }
