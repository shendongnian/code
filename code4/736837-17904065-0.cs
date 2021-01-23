    public static SqlConnection con;
    
    protected void Application_Start(object sender, EventArgs e)
    {
        con = new SqlConnection(_connectionString);
    }
    
