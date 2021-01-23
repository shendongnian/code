    protected void Page_Load(object sender, EventArgs e)
    {
       if(!Page.IsPostBack)
       {
          var welcomeLabel = Page.Master.FindControl("lblWelcome") as Label;
          SetName(welcomeLabel);
       }
    }
