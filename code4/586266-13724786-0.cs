    public static IEnumerable GetPolicies(int? MasterPkgID)
    {
    	// Create a list of policies belonging to the master package.
    	List<AdditionalInterestPolicyData> additionalInterestPolicyData = new List<AdditionalInterestPolicyData>();
    
    	// Set the SQL connection to the database.
    	SqlConnection objConn = new SqlConnection(ConfigurationManager.ConnectionStrings["QUESTIONNAIRE2"].ConnectionString);
    
    	SqlDataReader PolicyResult = null;
    
    	try
    	{
    		// Open the connection.
    		objConn.Open();
    
    		// Get the list of policies by executing a stored procedure.
    		SqlCommand PolicyCmd = new SqlCommand("p_expapp_get_policy_detail_by_master_pkg", objConn);
    		PolicyCmd.Parameters.Clear();
    		PolicyCmd.CommandType = CommandType.StoredProcedure;
    		PolicyCmd.Parameters.Add("@a_master_package_iden_key", SqlDbType.Int).Value = MasterPkgID;
    
    		PolicyResult = PolicyCmd.ExecuteReader();
    		// Loop thru the results returned.
    		while (PolicyResult.Read())
    		{
    			// Add to the list of policies - creates a new row for the collection.
    			additionalInterestPolicyData.Add(new AdditionalInterestPolicyData(
    													Int32.Parse(PolicyResult["affiliate_id"].ToString()),
    													Int32.Parse(PolicyResult["master_package_iden_key"].ToString())
    																			)
    											);
    		}
    	}
    	catch (Exception ex)
    	{
    		bError = true;
    	}
    	finally
    	{
    		if(PolicyResult != null) PolicyResult.Close();
    		objConn.Close();
    	}
    
    	return additionalInterestPolicyData;
    }
