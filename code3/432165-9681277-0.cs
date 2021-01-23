    get
    {
      if ( HttpContext.Current.Session["Application"] != null )
        return (JobApplication)HttpContext.Current.Session["Application"];
      return null;
    }
    set
    {
       ...
    }
