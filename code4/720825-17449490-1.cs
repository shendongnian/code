    protected string Image1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Image1 = Request.QueryString["ImageAlt1"];
        }
    }
