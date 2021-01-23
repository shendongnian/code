        if(HttpContext.Current.User.Identity.IsAuthenticated)
        {
            //Redirect user to Default page.
            Response.Redirect("default.aspx");
        }
