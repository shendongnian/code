    protected void Page_Load(object sender, EventArgs e)
    {
        myConnection.ConnectionString = ActionSource.ConnectionString;
        myConnection.Open();
        String account = User.Identity.Name;
        // ...
    }
