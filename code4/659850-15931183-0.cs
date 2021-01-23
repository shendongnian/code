    void Application_AcquireRequestState(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Session != null)
            {
                if (Session["language"] != null)
                {
                    Response.Write(Session["language"].ToString());
                }
            }
        }
