    DataTable dt = new DataTable(); 
    using(SqlConnection conn = new SqlConnection("yourConnectionString"))
    {
        SqlCommand cmd = new SqlCommand("SET FMTONLY ON; " + yourQueryString + "; SET FMTONLY OFF;",conn);  
        conn.Open(); 
        dt.Load(cmd.ExecuteReader()); 
    }
