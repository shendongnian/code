    //inside in your Business.User class (set reference to System.Web)
    public string GetLabelCompanyId()
    {
      string returnValue = String.Empty;
      HttpContext context = HttpContext.Current;
      if(context != null)
      {
         if(context.Session["CompanyId"] != null)
         {
            returnValue = context.Session["CompanyId"];
         }
      }
      return returnValue;
    }
