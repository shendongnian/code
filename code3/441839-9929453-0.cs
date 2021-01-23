    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            switch (UserControlType)
            {
                case "test":
                    ucTest1.Visible = true;
                ...
            }
        }
    }
    private string UserControlType
    {
        get { return Request.QueryString["uc"]; }
    }
