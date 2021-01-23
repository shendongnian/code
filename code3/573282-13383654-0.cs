    if(HttpContext.Current.Session["LoggedIn"]!=null)
    {
    
      if ((bool)HttpContext.Current.Session["LoggedIn"])
       {
        Response.Redirect("Default.aspx");
        }
    }
