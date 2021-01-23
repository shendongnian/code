    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            repeater.DataSource = theContext.GetOnlineFavorites(4);
            repeater.DataBind();
        }
    }
    protected void repeater_ItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if(e.CommandName == "OpenWindow")
        {
            string arg = e.CommandArgument; // this could be the url, or a userID to get favorites, or...?
            //Your open window script
        }
    }
