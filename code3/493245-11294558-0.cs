    int errorId = 0;
    SqlCommand cmd = new SqlCommand("YourSPName", cn);
    cmd.CommandType=CommandType.StoredProcedure;
    SqlParameter parm=new SqlParameter("@username",SqlDbType.VarChar);
    parm.Value=strUser;
    parm.Direction =ParameterDirection.Input ; 
    cmd.Parameters.Add(parm); 
    parm=new SqlParameter("@url",SqlDbType.VarChar);
    parm.Value=strUrl;
    parm.Direction =ParameterDirection.Input ; 
    cmd.Parameters.Add(parm); 
    parm=new SqlParameter("@errorID",SqlDbType.Int); 
    parm.Direction=ParameterDirection.Output; // This is important!
    cmd.Parameters.Add(parm); 
    cn.Open(); 
    errorId = (int)cmd.ExecuteNonQuery();
    cn.Close(); 
    sqlConnection.Open(); 
    sqlConnection.ExecuteNonQuery();
    
