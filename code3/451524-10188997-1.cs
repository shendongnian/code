    if(User.Identity.IsAuthenticated)
    {
        HttpContext.Current.Profile.SetPropertyValue("Startpage", startPage); //startPage is a String
        HttpContext.Current.Profile.Save();
    }
