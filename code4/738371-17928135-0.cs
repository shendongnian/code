    using (SqlConnection sqlConn = new SqlConnection(conString ))
    {
       try
       {
            //your sql statements here
        }
       catch (InvalidOperationException)
        {
            
        }
        catch (SqlException)
        {
           
        }
        catch (ArgumentException)
        {
            
        }
     }
