     void Application_AcquireRequestState(object sender, EventArgs e)
        {
            HttpContext context = HttpContext.Current;
            // CheckSession() inlined
            if (Context.Request.Url.LocalPath != "/UIComponents/User/Login.aspx")
            {
                if (context.Session["Name"] == null)
                {
                    FormsAuthentication.RedirectToLoginPage();
                }
            }
        }
