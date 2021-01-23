    public void SearchAffectedUser(Page page)
    {
      //some code here
      if (dr.Read())
      {
          //some code here
      }
      else
      {
          page.ClientScript.RegisterClientScriptBlock(this.GetType(), "clientScript", "<script type=\"text/javascript\">alert('Record Not Found. Please try again');</script>");
      }
    }
