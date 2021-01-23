    protected void Page_Load(object sender, EventArgs e)
    {
        if(!Page.IsPostBack) 
        {
            ListBoxDate.DataSource = GetAllDate(); /* it returns a list of objects Date   (which is a class with an attribute DateTime) */
           ListBoxDate.DataTextField = "_Date";
           ListBoxDate.DataValueField = "_Date";
           ListBoxDate.DataBind();
        }
    }
