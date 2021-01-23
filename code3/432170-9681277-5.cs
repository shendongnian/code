     get
            {
              if ( HttpContext.Current.Session["Application"] == null )
                  HttpContext.Current.Session["Application"] = JobApplicationFactory.CreateApplication();
              return (JobApplication)HttpContext.Current.Session["Application"];
            }
