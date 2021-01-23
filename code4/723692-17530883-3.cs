    SqlDataAdapter da = new SqlDataAdapter("spC", cs);
    da.SelectCommand.CommandType = CommandType.StoredProcedure;
    da.SelectCommand.Parameters.Add(new SqlParameter("@param_for_A", 123));
    da.SelectCommand.Parameters.Add(new SqlParameter("@param_for_B", "demo"));
    DataSet myDS = new DataSet();
    da.Fill(myDS);
