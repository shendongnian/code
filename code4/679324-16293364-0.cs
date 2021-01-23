    protected void Page_Load(object sender, EventArgs e)
            {
                if (!Page.IsPostBack)
                {
                 // Initially bind your grid view like
                    GridView1.DataSource = "DataSource";
                    GridView1.DataBind();
                }
            }
