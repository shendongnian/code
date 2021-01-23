    protected string Image1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string Image1 = Request.QueryString["ImageAlt1"]; // introduces a new variable named Image1
            // this.Image1 and Image1 are not the same variables
        }
        // local instance of Image1 is no more. (out of scope)
    }
