    void Application_Error(object sender, EventArgs e)
    {
      if(Context.IsCustomErrorEnabled)
      {
        Server.Transfer("~/Error.aspx");
      }
    }
