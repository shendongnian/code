    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
            {
                if(Membership.ValidateUser(Login1.UserName, Login1.Password))
                {
                    Response.Redirect("default.aspx");
                    // Set the user as logged in?
                }
    
            }
