        if(HttpContext.Current.User.Identity.IsAuthenticated)
        {
        
        //Redirect to Default page
        Response.Redirect("default.aspx");
        }
