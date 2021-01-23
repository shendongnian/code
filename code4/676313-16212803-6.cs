    using (OracleConnection oraconn = new OracleConnection())
    {
    	oraconn.ConnectionString = "Your_Connection_string";
    
    	using (OracleCommand cmd = new OracleCommand())
    	{
    	
    		cmd.Connection = oraconn;
    
    		cmd.CommandType = CommandType.StoredProcedure;
    		cmd.CommandText = "Your_Procedure_name";
    		oraconn.Open();
    		
    	
    		OracleParameter idParam = new OracleParameter("i_idList", OracleDbType.Int32, ParameterDirection.Input);
    		idParam.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
    		idParam.Value = idList.ToArray();
    		idParam.Size = idList.Count;
    
    		OracleParameter nameParam = new OracleParameter("i_nameList", OracleDbType.Varchar2, ParameterDirection.Input);
    		nameParam.CollectionType = OracleCollectionType.PLSQLAssociativeArray;
    		nameParam.Value = nameList.ToArray();
    		nameParam.Size = nameList.Count;
    
    		// You need this param for output
    		cmd.Parameters.Add("ret", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
    		cmd.Parameters.Add(idParam);
    		cmd.Parameters.Add(nameParam);
    
    		conn.Open();
    		
    		//If you need to read results ...
    		using (OracleDataReader dr = cmd.ExecuteReader())
    		{
    			while (dr.Read())
    			{
    				...
    			}
    		}
    		conn.Close();
    	}
    }
