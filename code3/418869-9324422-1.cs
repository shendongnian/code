    private void GetMultiSelect()
    {
        using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnect1"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = "usp_AllDetail";
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sqlParam = cmd.Parameters.Add("@Id", SqlDbType.Int, 4);
                sqlParam.Value = 1;
                //dataset object to get all select statement results
                DataSet ds = new DataSet();
                //sql dataadoptor to fill dataset
                using (SqlDataAdapter adp = new SqlDataAdapter(cmd))
                {
                    //here all select statements are fill in dataset object
                    adp.Fill(ds);
                    //now u can fetch each and every select statement by providing table index in dataset
                    foreach (DataTable dt in ds.Tables)
                    {
                        //select statement result in dt..
                    }
                    //or instead of loop u can specify the index
                   GridView1.DataSource= ds.Tables[1]; // first select statement result
                   GridView1.DataBind();
                   GridView2.DataSource = ds.Tables[0]; // second select statement result
                   GridView2.DataBind();
                }
            }
        }
    }
