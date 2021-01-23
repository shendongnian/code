    private void SomeMethod()
    {
       try
       {
          // Do some logic stuff
          ...
        
          if (someCondition)
          {
             Response.Redirect("ThatOneUrl.aspx", true);
          }
       }
       catch (ThreadAbortException)
       {
          // Do nothing.  
          // No need to log exception when we expect ThreadAbortException
       }
       catch (Exception ex)
       {
          // Looks like something blew up, so we want to record it.
          someLogger.Log(ex);
       }
    }
