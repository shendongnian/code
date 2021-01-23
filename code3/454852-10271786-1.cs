    protected void Page_Load(object sender, EventArgs e)
    {
        if ( !Page.IsPostBack ){
            HiddenField1.Value = "Initial Page Load Time: " + DateTime.Now.ToLongTimeString() + ". (Click to update current time in Label)";
        }
        Button1.Text = HiddenField1.Value;
        Label1.Text = "Current Time: " + DateTime.Now.ToLongTimeString();
    }
