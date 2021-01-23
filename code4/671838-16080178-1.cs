    using(SqlConnection con = new SqlConnection("your connection string")){
    conn.Open();
    using(var command = new SqlCommand("ProcedureName", conn)) { 
       command.CommandType = CommandType.StoredProcedure;
       
       SqlParameter param = new SqlParameter("@CustomerID",SqlDbType.Int);
       param.Value = /* your value */;
       param.Direction = ParameterDirection.Input; 
    
       SqlParameter param2 = new SqlParameter("@AppId",SqlDbType.Int); 
       param2.Direction  = ParameterDirection.Output;
      
       command.Parameters.Add(param);
       command.Parameters.Add(param2);
    
       command.ExecuteNonQuery();
       Console.WriteLine(command.Parameters["@AppId"].Value); 
       }
    }
