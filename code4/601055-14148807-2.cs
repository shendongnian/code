    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack)
        {
           allValidationMsg.Text = "Original text";
        } 
        else
        {
           allValidationMsg.Text = "After postback";
        }
    }
