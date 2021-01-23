        void Application_AcquireRequestState(object sender, EventArgs e)
        {
            HttpContext context = HttpContext.Current;
            Page page = context.Handler as Page;
            if ((string)context.Session["LoggedIn"] != "true"
                && !(page.AppRelativeVirtualPath == "~/Default.aspx"))
                context.Response.Redirect("default.aspx");
        }
