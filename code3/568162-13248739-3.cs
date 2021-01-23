    protected void Page_Load(object s, EventArgs e)
    {
        if (!Page.IsPostback)
        {
            int rowID = int.Parse(Request.QueryString["id"]);
            // do something with the ID of the row, like go and look
            // up JUST that row again
        }
    }
