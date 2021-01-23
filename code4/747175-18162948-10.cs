    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings[1].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                con.Open();
                var ddl = (DropDownList)e.Row.FindControl("ddlState");
                int CountryId = Convert.ToInt32(e.Row.Cells[0].Text);
                SqlCommand cmd = new SqlCommand("select * from State where CountryID=" + CountryId, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                con.Close();
                ddl.DataSource = ds;
                ddl.DataTextField = "StateName";
                ddl.DataValueField = "StateID";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }
