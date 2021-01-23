     protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    getDeveloperId();
                }
            }
            public void getDeveloperId()
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT [DeveloperId], [DeveloperName] FROM [DB].[dbo].[tbl]", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                DropDownList1.DataSource = ds.Tables[0];  //bind the ddp_dataview to dataview
                DropDownList1.DataTextField = "DeveloperName";
                DropDownList1.DataValueField = "DeveloperId";
                DropDownList1.DataBind();
            }
