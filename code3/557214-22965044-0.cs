    if (User.Identity.IsAuthenticated)
    {
	    return RedirectToAction("Index", "Home");
    }
    System.Web.Helpers.AntiForgery.Validate();
    /* proceed with authentication here */
