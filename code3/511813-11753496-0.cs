     protected void Button1_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\jayant\Documents\User_Details.accdb";
            con.Open();
            adapter = new OleDbDataAdapter("Select * from User_Details",con);
            adapter.Fill(ds);
            GridView1.DataSource = ds;
            Session.Add("Dataset", ds); //Adding Session here
            GridView1.DataBind();
            con.Close();
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            DataSet ds = (DataSet)Session["Dataset"]; //Retrieving Value from session
            ds.WriteXml("C:\\MyUser_Details.xml");
        }
