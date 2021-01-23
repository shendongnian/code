    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DoSomething(Request["SectionID"]);
        }
    }
    private void DoSomething(string SectionID)
    { 
        // make database call against SectionID and fetch whether its approved or not.
    }
