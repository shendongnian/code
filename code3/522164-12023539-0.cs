        call your stored procedure with sqlcommand to fill your datatable
        
        using (SqlConnection scn = new SqlConnection(connect)
       {
        
        SqlCommand spcmd = new SqlCommand("search", scn);
        
        spcmd.Parameters.Add("@blah", SqlDbType.VarChar, -1); //or SqlDbType.NVarChar
         
        spcmd.CommandType = System.Data.CommandType.StoredProcedure;
        
         using (SqlDataAdapter da = new SqlDataAdapter(spcmd)) 
                    { 
                        da.Fill(dt); 
                    } 
        }
