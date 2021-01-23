    public void UserPasswordChangedHandler()
    {
      FormsAuthentication.SignOut();
      Roles.DeleteCookie();
      Session.Clear();
    }
