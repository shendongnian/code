    using (var cn = new OracleConnection(connString))
    {
      var sql = "select projectName, managerName from project where projectID = :p1";
      using (var cmd = new OracleCommand(sql, cn))
      {
        cmd.BindByName = true; 
        cmd.Parameters.Add(new OracleParameter(":p1", OracleDbType.Decimal, projectID,
                                                ParameterDirection.Input));
        using (var adapter = new OracleDataAdapter(cmd))
        {
          cn.Open();
          var dataSet = new DataSet();
          adapter.Fill(dataSet);
          return dataSet;
        }
      }
    }
