    // controller
    ActionResult MyAction()
    {
        if (!User.Identity.IsAuthenticated)
        {
            ViewBag.MenuControl = "Menu/NotLoggedIn"
        } 
        else if (User.IsInRole("Administrator"))
        {
            ViewBag.MenuControl = "Menu/Administrator"
        } 
        else
        {
            ViewBag.MenuControl = "Menu/LoggedIn"
        }
        ...
    }
    // view
    @Html.Partial(ViewBag.MenuControl);
