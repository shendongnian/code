    protected void Page_Load(object sender, EventArgs e)
    {
        if(IsPostBack) {
            string username = Page.Session["username"] as string; // will be null if empty
            Resopnse.Write(username);
        }
        btnSubmit.UseSubmitBehavior = false;
    }
