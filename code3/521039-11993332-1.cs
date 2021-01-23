    public DataTable GetData()
    {
        SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["BarManConnectionString"].ConnectionString);
        conn.Open();
        string query = "SELECT * FROM [EventOne]";
        SqlCommand cmd = new SqlCommand(query, conn);
    
        DataTable dt = new DataTable();
        dt.Load(cmd.ExecuteReader());
        conn.Close();
        return dt;
    }
