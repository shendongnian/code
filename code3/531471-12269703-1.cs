    public ActionResult SendErrorReporAction()
    {
        if(!CertainCondition)
        {
            return Redirect(Request.QueryString["url"]);
        }
    }
