    xSqlConnections con = new SqlConnections("System.Configuration.ConfigurationManager.ConnectionStrings["WebNewYearConnectionString"].ConnectionString");
            protected void Page_Load(object sender, EventArgs e)
            {
                con.open();
        
                string Clientname = Request.QueryString["name"];
                string str = "select * from Client_Detail where Client_Name='" + Clientname + "'";
                DataTable dat;
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                da.Fill(ds, "tab");
                DataTable dat = new DataTable();
                dat = ds.Tables["tab"];
                EventName.Text = dat.Rows[0]["Event_Name"].ToString();
                Event_Description.Text = dat.Rows[0]["Description"].ToString();
                Event_Date.Text = dat.Rows[0]["Date"].ToString();
                Entry_Fee.Text = dat.Rows[0]["Price"].ToString();
                Event_Client.Text = dat.Rows[0]["Client_Name"].ToString();
                Event_Location.Text = dat.Rows[0]["Event_Location"].ToString();
                Session["Event_Name"] = EventName.Text;
        
                con.Close();
            }
