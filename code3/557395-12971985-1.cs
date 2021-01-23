    if (System.Web.HttpContext.Current.Session["company_path"]!= null)
    {
          company_path = System.Web.HttpContext.Current.Session["company_path"].ToString();
    }
    else
    {
          company_path = "/reflex/SMD";
    }
