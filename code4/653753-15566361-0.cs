    SqlConnection con = new SqlConnection(connectionString);
    if (con.State==ConnectionState.Closed)
    {                      
        con.Open();   
    }
    
    // here your code goes for sql operations
    
    con.Close();
