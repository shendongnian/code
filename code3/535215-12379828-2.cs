    public void NameChangedHandler()
    {
      FormsAuthentication.SignOut();
      Roles.DeleteCookie();
      Session.Clear();
    }
