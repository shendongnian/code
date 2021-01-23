    using(SqlConnection conn = new SqlConnection(YourConnectionStringHere))    
    {
      
         SqlCommand cmd = new SqlCommand(YourSQLQuery, conn);
      
         SqlDataReader dr = cmd.ExecuteReader();
      
         while(dr.Read())      
         {
       
           Label1.Text = dr[1].ToString();
        
           // This is just an example. You can do whatever you want. :)
      
         }
    
    }
