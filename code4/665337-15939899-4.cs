    public ActionResult Index()
    {
        if (Session["sessionid"] == null)
            Session["sessionid"] = "empty";
        // check to see if your ID in the Logins table has LoggedIn = true - if so, continue, otherwise, redirect to Login page.
        if (OperationContext.IsYourLoginStillTrue(System.Web.HttpContext.Current.User.Identity.Name, Session["sessionid"].ToString()))
        {
            // check to see if your user ID is being used elsewhere under a different session ID
            if (!OperationContext.IsUserLoggedOnElsewhere(System.Web.HttpContext.Current.User.Identity.Name, Session["sessionid"].ToString()))
            {
                return View();
            }
            else
            {
                // if it is being used elsewhere, update all their Logins records to LoggedIn = false, except for your session ID
                OperationContext.LogEveryoneElseOut(System.Web.HttpContext.Current.User.Identity.Name, Session["sessionid"].ToString());
                return View();
            }
        }
        else
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
