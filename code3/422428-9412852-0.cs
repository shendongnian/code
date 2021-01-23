     //get the connection string from web.config
            string connString = ConfigurationManager .ConnectionStrings["Platform"].ConnectionString;
            DataSet dataset = new DataSet();
    
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();                
                adapter.SelectCommand = new SqlCommand("select * from [NAMES]", conn);
                conn.Open(); 
                adapter.Fill(dataset);
    
            }  
