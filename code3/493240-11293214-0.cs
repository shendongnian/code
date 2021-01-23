    Use following code,
    SqlCommand cmd = new SqlCommand("MyStoredProcedure", cn);
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
    cmd.ExecuteNonQuery();
    cn.Close(); 
    
    // Print the output value
    Console.WriteLine(cmd.Parameters["@errorID"].Value); 
    Console.ReadLine();
