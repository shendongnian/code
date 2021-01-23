    [AllowAnonymous]
    public ActionResult Register()
    {
        RegisterModel rm = new RegisterModel();
    
        rm.Categories = new List<SelectListItem>();//added line 
    
        rm.Categories.Add(new SelectListItem { Value = null, Text = "Guest" });
    ...
