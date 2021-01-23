   // suppose if you are willing to redirect a user according to his/her role
protected void LoginUser_LoggedIn(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
            {
                // if user in role and authenticated 
                if (Roles.IsUserInRole(LoginUser.UserName, "Developers"))
                {
                    // add session and redirect to particular page
                    Session.Add("developer", "Developers");
                    Response.Redirect("../Developers/devAccess.aspx");
                }
            }
        }
