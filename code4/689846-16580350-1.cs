    using (SqlConnection conn = new SqlConnection("my connection string"))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Students", conn);
                    conn.Open();
                    SqlDataAdapter _adp = new SqlDataAdapter(cmd);
                    DataSet ds = new DataTable();
                    _adp.Fill(ds);
                    GridView1.DataSource = ds.Tables[0];
    
                    GridView1.DataBind();
                }
