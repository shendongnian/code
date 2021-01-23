    if (User.Identity.IsAuthenticated)
    {
        String startPage = HttpContext.Current.Profile.GetPropertyValue("Startpage") as string;
        if (!string.IsNullOrWhiteSpace(startPage))
        {
            Response.Redirect(startPage);
        }
    }
