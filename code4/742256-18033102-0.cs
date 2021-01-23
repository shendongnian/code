    void Application_AcquireRequestState(object sender, EventArgs e)
    {
        if (System.Web.HttpContext.Current.Session != null)
        {
            if (Session["locale"] != null)
            {                  
                 //already set variable
            }
            else
            {
                //set some variable
                Session["locale"] = true;
            }
        }
    }
