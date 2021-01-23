    OracleCommand command = myOracleConnection.CreateCommand();
    command.CommandText = "MISSINGTABLES";
    command.Parameters.Add(new OracleParameter("S1", OracleType.VarChar)).Value = "PEKA_ERP_001";
    command.Parameters.Add(new OracleParameter("S2", OracleType.VarChar)).Value = "ASE_ERP_001";
    command.CommandType = System.Data.CommandType.StoredProcedure;
    command.ExecuteNonQuery();
    myOracleConnection.Close();
