        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet ds =  // Get Data from DB
                GridView1.DataSource = ds.Tables[0];
                GridView1.DataBind();
            }
        }
