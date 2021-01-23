    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["MyFlag"] != null)
            {
                //Perform whatever you need to do with your already saved generic list in Session
                Session["MyFlag"] = null;
            }
        }
    }
