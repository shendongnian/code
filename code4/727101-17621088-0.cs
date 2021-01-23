    void Page_Load( ... )
    {
        if (!Page.IsPostBack)
        {
            if (QueryString["VisitFlag"] == null)
                Response.Redirect("Welcome.aspx?VisitFlag=Done");
        }
    }
