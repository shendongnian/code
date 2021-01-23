    command.Parameters.Add(new OracleParameter
                                {
                                    ParameterName = "param_out",
                                    OracleDbTypeEx = OracleDbType.Decimal,
                                    Direction = ParameterDirection.Output
                                });
    if (command.Parameters["param_out"].Value != Convert.DBNull)
    {
      //your code here
    }
