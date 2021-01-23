    protected void Page_Load(object sender, EventArgs e)
    {
        bind();
        if (!Page.IsPostBack)
        {
            bind();
        }
    }
