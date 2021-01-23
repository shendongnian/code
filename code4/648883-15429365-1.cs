    private DataTable RetrieveStatus()
    {
        //fetch the connection string from web.config
        string connString = ConfigurationManager.ConnectionStrings["sb_cpdConnectionString"].ConnectionString;
        //SQL statement to fetch entries from products
        string sql = @"Select distinct Status from cpd_certificates";
        DataTable dtStatus; = new DataTable();
        //Open SQL Connection
        using (SqlConnection conn = new SqlConnection(connString))
        {
            conn.Open();
            //Initialize command object
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //Fill the result set
                adapter.Fill(dtStatus;);
            }
        }
        return dtStatus;
    }
