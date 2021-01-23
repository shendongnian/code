    oraConn.Open();
    
    OracleCommand cursCmd = new OracleCommand("CURSPKG.OPEN_TWO_CURSORS", oraConn);
    cursCmd.CommandType = CommandType.StoredProcedure;
    cursCmd.Parameters.Add("EMPCURSOR", OracleType.Cursor).Direction = ParameterDirection.Output;
    cursCmd.Parameters.Add("DEPTCURSOR", OracleType.Cursor).Direction = ParameterDirection.Output;
    
    OracleDataReader rdr = cursCmd.ExecuteReader();
    
    Console.WriteLine("\nEmp ID\tName");
    
    while (rdr.Read())
      Console.WriteLine("{0}\t{1}, {2}", rdr.GetOracleNumber(0), rdr.GetString(1), rdr.GetString(2));
    
    rdr.NextResult();
    
    Console.WriteLine("\nDept ID\tName");
    
    while (rdr.Read())
      Console.WriteLine("{0}\t{1}", rdr.GetOracleNumber(0), rdr.GetString(1));
    
    rdr.Close();
    oraConn.Close();
