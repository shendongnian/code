    int errorId = 0;
    
    using(SqlConnection sqlConnection = new SqlConnection(connectionString))
    {
    	using(SqlCommand cmd = new SqlCommand("YourStoredProcedureName", sqlConnection))
        {
    	cmd.CommandType=CommandType.StoredProcedure;
    	SqlParameter parm=new SqlParameter("@username", SqlDbType.VarChar); 
    	parm.Value="mshiyam";
    	parm.Direction =ParameterDirection.Input ; 
    	cmd.Parameters.Add(parm); 
    
    	SqlParameter parm2=new SqlParameter("@path",SqlDbType.VarChar); 
    	parm2.value = "Some Path";
    	parm2.Direction=ParameterDirection.Output;
    	cmd.Parameters.Add(parm2); 
    
    
    	SqlParameter parm3 = new SqlParameter("@errorId",SqlDbType.Int);
    	parm3.Direction=ParameterDirection.Output; 
    	cmd.Parameters.Add(parm3); 
    
    	sqlConnection.Open(); 
    	sqlConnection.ExecuteNonQuery();
    
    	errorId = cmd.Parameters["@errorId"].Value; //This will 1 or 0
       }
    
    }
