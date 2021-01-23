    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string content = GetContent();
            txtHTMLContent.Text = content;
        }
    }
