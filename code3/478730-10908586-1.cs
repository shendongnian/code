    // define connection and command, in using blocks to ensure disposal
    using(SqlConnection conn = new SqlConnection(pvConnectionString ))
    using(SqlCommand cmd = new SqlCommand("dbo.usp_InsertContract", conn))
    {
        cmd.CommandType = CommandType.StoredProcedure;
            
        // set up the parameters
        cmd.Parameters.Add("@ContractNumber", SqlDbType.VarChar, 7);
        cmd.Parameters.Add("@NewId", SqlDbType.Int).Direction = ParameterDirection.Output;
        // set parameter values
        cmd.Parameters["@ContractNumber"].Value = contractNumber;
        // open connection and execute stored procedure
        conn.Open();
        cmd.ExecuteNonQuery();
        // read output value from @NewId
        int contractID = Convert.ToInt32(cmd.Parameters["@NewId"].Value);
        conn.Close();
    }
