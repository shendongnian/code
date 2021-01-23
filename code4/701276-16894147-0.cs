    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            avatarImage.ImageUrl = "~/images/avatars/" + Session["avatar"] + ".gif";
            avatarDropList.SelectedValue = Session["avatar"].ToString();
            userNameTextbox.Text = Session["user"].ToString();
            newPasswordTextbox.Text = Session["password"].ToString();
        }
    }
