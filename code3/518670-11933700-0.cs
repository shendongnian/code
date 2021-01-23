    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConectionString"].ConnectionString);
    
                SqlCommand cmd = new SqlCommand("Select * from Tbl_Employee", con);
    
                SqlDataAdapter da = new SqlDataAdapter(cmd);
    
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        gv1.DataSource = ds.Tables[0];
                        gv1.DataBind();
                    }
                }
