     if (Membership.ValidateUser(UserName, password.Text))
          {
          string[] role = Roles.GetRolesForUser(username.Text);
          string userrole = role[0].ToString();
    
          FormsAuthentication.SetAuthCookie(UserName, true);
          // Above line will create a Cookie on Browser and you can use this to check the authentication of the user. 
          if (userrole == "User")
              {
                  Response.Redirect("~/Default.aspx", true);
              }
          else
              {
                  Response.Redirect("~/UnAuthorizedPage.aspx", true);
              }
     }
