    private void Page_Load(object sender, System.EventArgs e)
    {
        // Put user code to initialize the page here
        Session.Abandon();
        FormsAuthentication.SignOut();
    }
