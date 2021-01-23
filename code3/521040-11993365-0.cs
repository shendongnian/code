    public DataTable GetDataTable()
    {
    SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["BarManConnectionString"].ConnectionString);
    conn.Open();
    string query = "SELECT * FROM [EventOne] ";
    
    SqlCommand cmd = new SqlCommand(query, conn);
    
    DataTable t1 = new DataTable();
    using (SqlDataAdapter a = new SqlDataAdapter(cmd))
    {
        a.Fill(t1);
    }
    return t1;
    }
