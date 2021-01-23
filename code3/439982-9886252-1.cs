            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    List<string> lstObjects = new List<string> { "aaa", "bbb" };
                    GridView1.DataSource = lstObjects;
                    GridView1.DataBind();
                }
            }
