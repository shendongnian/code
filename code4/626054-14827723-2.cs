    protected void btnLogin_Click(object sender, EventArgs e)
    {
       string username = txtUserName.Text.Trim();
       string password = txtPassword.Text.Trim();
       if (Membership.ValidateUser(username, password))
       {
         //...             
       }
       else
       {
           Response.Redirect("Hello.aspx");
       }
    }
