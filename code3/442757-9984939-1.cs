    protected void Page_Load(object sender, EventArgs e)
            {
                if (!Page.IsPostBack)
                {
                     GridView1.DataSource = GetUserScraps();
                     GridView1.DataBind();
                }
            }
