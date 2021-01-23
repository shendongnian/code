    public SqlConnection OpenConnection()
            {
                try
                {
                    var  conn = new SqlConnection(“xxx”);
                    conn.Open();
                    return conn;
                }
                catch (Exception ex)
                {
                    //log the exception
                    return null;
                }
            }
    
    YourFunction(parameters)
    {
    	var conn = OpenConnection();
    	if(conn != null)
    	{
    		//your code
    		// you can do something similar as JeremyK explained here 
        }
    
    }
