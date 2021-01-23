       if (!Page.IsPostBack)
    {
        if (Request.IsAuthenticated && !string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
           {
              Response.Redirect("Acces page");
            }
           else
           {
            Response.Redirect("/App/Error/UnauthorizedAccess.aspx");
           }
    }
