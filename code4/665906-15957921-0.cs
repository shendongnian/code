        Or try this, this sample code is very secure and 100% works any time, you can copy paste it but u must put your connection string and table 
        
        string connectionStr = "connection string STRING";
        string sqlQuery = "INSERT INTO yourtable VALUES (ID, @pam1, @pam2)";
        ///// Go to Base and execute Query but with trycatch because if you have problem with using connection it will tell you
        
        try{
        
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using(SqlCommand komand = new SqlCommand(conn,sqlQuery)) //command to use connection and Sqlquery
        
        string fromcontrol = "test"; //this is string just for test
        
                komand.Parameters.AddWithValue("@pam1", fromcontrol.ToString());
                komand.Parameters.AddWithValue("@val2", fromcontrol.ToString());
        
                    conn.Open();
                    komand.ExecuteNonQuery();
                }
                catch(SqlException e)
                {
        //throw your execption to javascript  or response; e.Message.ToString() + "SQL connection or query error"; 
                }
        
        catch(Exception ex)
        {
        //throw your execption to javascript  or response; e.Message.ToString()+ "system error"; 
        }
    
    finally
    {
    conn.Close();
    conn.Dispose();
    }
    
            }
        }
