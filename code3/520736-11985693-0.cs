    if (Membership.ValidateUser(userName.Text, password.Text))
    {
      if (Request.QueryString["ReturnUrl"] != null)
      {
        FormsAuthentication.RedirectFromLoginPage(userName.Text, false);
      }
      else
      {
        FormsAuthentication.SetAuthCookie(userName.Text, false);
      }
    }
    else
    {
      Response.Write("Invalid UserID and Password");
    }
