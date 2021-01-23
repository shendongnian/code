    ActionResult RenderMenu()
    {
        string template;
        if (!User.Identity.IsAuthenticated)
        {
            template = "Menu/NotLoggedIn"
        } 
        else if (User.IsInRole("Administrator"))
        {
            template = "Menu/Administrator"
        } 
        else
        {
            template = "Menu/LoggedIn"
        }
        return View(template);
    }
    // view
    @Html.Action("RenderMenu", "MenuController")
