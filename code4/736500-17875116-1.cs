    public bool SearchAffectedUser(Page page)
    {
      //some code here
      if (dr.Read())
      {
          //some code here
      }
      else
      {
          return false;
      }
      return true;
    }
    
    //inside your Page class
    protected void Page_Load(object sender, EvetArgs e)
    {
       //logic
       if (!obj.SearchAffectedUser())
       {
          this.ClientScript.RegisterClientScriptBlock(this.GetType(), "clientScript", "<script type=\"text/javascript\">alert('Record Not Found. Please try again');</script>");
       }
    }
