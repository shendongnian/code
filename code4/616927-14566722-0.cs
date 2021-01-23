    using(var conn = new SqlConnection(cCon.getConn())
    {
            using(var cmd = new SqlCommand("sp_getUserOrgs", conn))
            {
               cmd.CommandType = CommandType.StoredProcedure;
               cmd.Parameters.Add(new SqlParameter("@UserID", UserID));
    
              try 
              {
                conn.Open();
                SqlDataAdapter sqlDA = new SqlDataAdapter();
    
                sqlDA.SelectCommand = cmd;
                sqlDA.Fill(ds);
             
                foreach (DataRow dr in ds.Tables[0].Rows) 
                {  
                   userorgs.Add(dr["orgs_column"].ToString()); 
                }
              } 
              catch (Exception ex) 
              {
                //treat your exception
              } 
          }       
      }
