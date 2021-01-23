    public void run_runcommand(string query)   
    {
        using(var con = new SqlConnection(connectionString))
        using(var cmd = new SqlCommand(query, con))
        {
            con.Open();
            // ...
        }  // close not needed since dispose also closes the connection
    }
