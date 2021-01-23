        public ActionResult Index()
        {
            try
            {
                List<string> rights = objAuthorization.CheckMemberRightsOnPage("page1");
                if (!rights.Contains("View"))
                {
                    if (Session["UserID"] == null && Request.IsAjaxRequest())
                    {
                        return Content("<div class=\"error\">Your session was expired. Press Logout and then login again to continue</div>");
                    }
                    return RedirectToAction("Restricted", "UserLogin", new { url = HttpUtility.HtmlEncode(Request.Url.AbsolutePath.Substring(1)) });
                }
                ViewData["objAuthorization1"] = rights;
            //  your other things here
            }
            catch(Exception ex){
               ViewData["ErrorMessage"] = "An error occurred: " + ex.Message;
                return View();   } 
        }
