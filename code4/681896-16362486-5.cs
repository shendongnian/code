    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            if (Request["__EVENTTARGET"] == "btnNew" && 
                Request["__EVENTARGUMENT"] == "MyArgument")
            {
                //do something
            }
        }
    }
