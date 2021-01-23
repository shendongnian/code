    protected void Page_Load(object sender, EventArgs e)
    {
        if ( !Page.IsPostBack ){
            Button1.Text = "Initial Page Load Time: " + DateTime.Now.ToLongTimeString() + ". (Click to update current time in Label)";
        }
        Label1.Text = "Current Time: " + DateTime.Now.ToLongTimeString();
    }
