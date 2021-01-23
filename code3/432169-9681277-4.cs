    get
        {
          if ( HttpContext.Current.Session["Application"] == null )
              HttpContext.Current.Session["Application"] = new JobApplication();
          return (JobApplication)HttpContext.Current.Session["Application"];
        }
