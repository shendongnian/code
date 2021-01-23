    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack){
            LoadGridView();
        }
    }
    private void LoadGridView()
    {
        this.GridView.DataSource = GetUsersFromDatabase();
        this.GridView.DataBind();
    }
    
    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var user = e.Row.DataItem as UserModel;
            var enabledImgBtn = e.Row.FindControl("EnabledImgBtn") as ImageButton;
            if (enabledImgBtn != null)
                enabledImgBtn.ImageUrl = user.IsEnabled ? "~/YourImagePath/enabled.png"
                                                        : "~/YourImagePath/disalbed.png";
        }
    }
    
    protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "ResetUserState")
        {
            if (e.CommandArgument!= null)
               { 
                var userName = e.CommandArgument.ToString();            
                //Change user enabled state and Update database
                //Sample code:
                 var user = FindUserByName("userName");
                 user.IsEnabled = !user.IsEnabled;
                 //SaveInDatabase(user);
                 LoadGridView();
               }
        }
    }
