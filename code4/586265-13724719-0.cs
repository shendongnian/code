    try
    {
        // Open the connection.
        objConn.Open();
        // Get the list of policies by executing a stored procedure.
        using (SqlCommand PolicyCmd = new SqlCommand("p_expapp_get_policy_detail_by_master_pkg", objConn))
        {
               PolicyCmd.Parameters.Clear();
               PolicyCmd.CommandType = CommandType.StoredProcedure;
               PolicyCmd.Parameters.Add("@a_master_package_iden_key", SqlDbType.Int).Value = MasterPkgID;
               using (SqlDataReader PolicyResult = PolicyCmd.ExecuteReader())
               {
                   // Loop thru the results returned.
                   while (PolicyResult.Read())
                   {
                      // do your stuff here....
                   }
               }
        }
    }
