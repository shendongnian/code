    DataSet domain = new DataSet();
    DataTable dataFromA = null;
    DataTable dataFromB = null;
    
    using(SqlConnection conn1 = new SqlConnection("FirstConnectionString"))
    {
      DataTable dataFromA = //result from SELECT id, name FROM TableA
    }
    
    
    using(SqlConnection conn2 = new SqlConnection("SecondConnectionString"))
    {
      DataTable dataFromB = //result from SELECT id, name FROM TableB
    }
    domain.Tables.Add(dataFromA);
    domain.Tables.Add(dataFromB);
