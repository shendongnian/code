    SqlConnection conn = new SqlConnection(getConnectionString())
    SqlCommand cmd = new SqlCommand("SP_ProfileRegMaster", conn);
    cmd.CommandType = CommandType.StoredProcedure;
    // Pass parameters to Stored Proc...
    // Add one more parameter to store the Return Value
    var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
    returnParameter.Direction = ParameterDirection.ReturnValue;
    conn.Open();
    cmd.ExecuteNonQuery();
    // Retrieve the return value
    var result = returnParameter.Value;
