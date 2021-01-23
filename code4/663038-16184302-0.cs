    protected void hypTit_Click(object sender, EventArgs e)
        {
            if (sender is LinkButton)
            {
                lstArt.Visible = true;
                LinkButton btn = (LinkButton)sender;
                string buttonpressed = btn.Text.ToString();
                fillVals(buttonpressed);
            }
        }
        protected void fillVals(String name)
        {
            string cxnstr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(cxnstr);
            conn.Open();
            DataSet ds;
            try
            {
                ds = new DataSet("ds");
                SqlDataAdapter da = new SqlDataAdapter("select Title,[Description]as[Article] from StandardReplies where CatRowID = " + catID + " and Title like '" + name + "'", conn);
                da.Fill(ds);
                lstArt.DataSource = ds;
                lstArt.DataBind();
            }
            catch (SqlException ex)
            {
                Response.Write(ex.ToString());
            }
        }
