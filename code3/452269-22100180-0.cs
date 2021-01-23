    void RegisterForChanges()
    {
      _sqlCommand.Notification = null;
      _sqlConnection.Open();
      SqlDependency dependency = new SqlDependency(_sqlCommand);
      dependency.OnChange += dependency_OnChange;
      _sqlCommand.ExecuteNonQuery(); // or ExecuteReader and parse the results, etc
      _sqlConnection.Close();
    }
