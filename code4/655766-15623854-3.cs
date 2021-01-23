    protected void btnLogout_Click(object sender, EventArgs e)
    {
       Session.Abandon();
       //or
       //Session.Remove("loggedIn");
    }
