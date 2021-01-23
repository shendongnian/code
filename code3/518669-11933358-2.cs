            con.Open();    
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds, "Emp");   // SEE THIS LINE!
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    Label2.Text = string.Empty;
                }
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
                Label2.Text = "Data not found";
            }
            con.Close();
