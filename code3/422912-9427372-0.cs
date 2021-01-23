    using(var conex=GetConnection())
    {
       try
       {
         conex.Open(); 
         //do stuff
        var cmd= new SqlCommand();//cfg command
        using (var rd= cmd.ExecuteReader())   
          {
               //do read
          }
       }
       catch(Exception ex)
        {
           //handle exception
        }
    }
