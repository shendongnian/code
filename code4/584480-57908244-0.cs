    using (OdbcConnection DbConnection = new OdbcConnection("ConnectionString"))
    {
	  DbConnection.Open();
	  using (OdbcCommand DbCommand = DbConnection.CreateCommand())
	  {
		DbCommand.CommandText = "INSERT...";
		DbCommand.Parameters.Add("@Name", OdbcType.Text, 20).Value = "name";
		DbCommand.ExecuteNonQuery();
		
		DbCommand.Parameters.Clear();
		DbCommand.Parameters.Add("@Name", OdbcType.Text, 20).Value = "name2";
		DbCommand.ExecuteNonQuery();
	  }
    }
