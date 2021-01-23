    if Session["username"] != null
    {
      String username = Session["username"].ToString();
    }
    else
    {
      Page.Redirect("login.aspx");
    }
