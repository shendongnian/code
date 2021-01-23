    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack) // If you not place this check then you will get the old values because GridView in Bind on every postback
        {
            BindGrid(); // Bind you grid here
        }
    }
