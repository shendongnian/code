    public DataTable GetDataTable()
            {
                DataTable dt = new DataTable();
    
                using (SqlConnection con = new SqlConnection (@"YourCOnnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand (query, con))
                    {
                        var adaptor = new SqlDataAdapter ();
                        adaptor.SelectCommand = cmd;
    
                        con.Open();
                        adaptor.Fill(dt);
    
                        return dt;
    
                    }
                }
            }
