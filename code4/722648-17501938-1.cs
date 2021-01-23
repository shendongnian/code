    public static int ExecuteOutputIntParam(string aProcName, string outputParamName, List<SqlParameter> aSqlParams)
    {
        int outValue = -1;
        using (SqlConnection conn = new SqlConnection(DatabaseConnectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(aProcName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            if (aSqlParams != null)
                foreach (SqlParameter lP in aSqlParams)
                    cmd.Parameters.Add(lP);
            int result = cmd.ExecuteNonQuery();
            if (aSqlParams != null)
            {
                outValue = Convert.ToInt32(aSqlParams[outputParamName].Value);
                
            } 
        }
        return outValue;
    }
