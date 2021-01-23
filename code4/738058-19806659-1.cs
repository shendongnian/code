    //create a connection
    string conString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionName"].ConnectionString;
    OracleConnection con = new OracleConnection(conString);
    
    //create SQL and insert parameters
    OracleCommand cmd = new OracleCommand("insert into daily_cdr_logs (message) values (:_message)", con);
    cmd.Parameters.Add(new OracleParameter("_message", msg));
        try
        {
            //if connection is closed, open it
            if (con.State == ConnectionState.Closed)
                 con.Open();
 
                 //execute query
                 cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
             //do something with the error
        }
        finally
        {
             //if connection is open, close it
             if (con.State == ConnectionState.Open)
             con.Close();
        }
