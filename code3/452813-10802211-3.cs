    string connStr = "User Id=xxx;Password=xxxx;Data Source=xxxxx;";
    OracleConnection _conn = new OracleConnection(connStr);
    _conn.Open();
     
    OracleCommand cmd = _conn.CreateCommand();
    cmd.CommandText = "some_package.ins_test";
    cmd.CommandType = CommandType.StoredProcedure;
     
    OracleParameter p1 = new OracleParameter();
    OracleParameter p2 = new OracleParameter();
     
    p1.OracleDbType = OracleDbType.Decimal;
    p1.Direction = ParameterDirection.Input;
    p2.OracleDbType = OracleDbType.Decimal;
    p2.Direction = ParameterDirection.Output;
     
    p1.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
    p1.Value = new int[3] { 1, 2, 3 };
    p1.Size = 3;
     
    cmd.Parameters.Add(p1);
    cmd.Parameters.Add(p2);
     
    cmd.ExecuteNonQuery();
