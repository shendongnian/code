    using (DbCommand command = connection.CreateCommand())
    {
        connection.Open();
    		
    	command.CommandType = CommandType.StoredProcedure;
    	command.CommandText = "pkg_vendor_config.get_ledger_codes";
    		
    	OracleParameter[] yourParams = new[] 
    	{ 
    		new OracleParameter("i_vendor", OracleDbType.Varchar2, "subs", ParameterDirection.Input), 
    		new OracleParameter("i_payment_type", OracleDbType.Varchar2, "cold hard cash", ParameterDirection.Input),
    		new OracleParameter("o_allocated_ledgercode", OracleDbType.Varchar2, ParameterDirection.Output), 
    		new OracleParameter("o_unallocated_ledgercode", OracleDbType.Varchar2, ParameterDirection.Output)
    	};
    		
    	foreach(var param in yourParams)
        {
             param.Size = 50;
        }
    
    	command.Parameters.AddRange (yourParams);
    
    	command.ExecuteNonQuery();
    		
    	var unallocated = (String)command.Parameters["o_unallocated_ledgercode"].Value.ToString();
    	var allocated = (String)command.Parameters["o_allocated_ledgercode"].Value.ToString();
        connection.Close();
    }
