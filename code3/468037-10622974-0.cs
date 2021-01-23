    public static void AuthorizeRequest(Action<string> redirect)
    {
        if( /*whatever*/ )
            redirect("/InvalidPermissions.htm");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        AuthorizeRequest(Response.Redirect);
    }
