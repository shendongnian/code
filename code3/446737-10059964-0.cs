    public ActionResult Register()
    {
     //If validation ok, save
     if (createStatus == MembershipCreateStatus.Success)
     {
       //dio stuff
     }
     else
     { 
        List<SelectListItem> list = new List<SelectListItem>();
        SelectListItem item; 
        foreach (String role in Roles.GetAllRoles()) 
        { 
            item = new SelectListItem { Text = role, Value = role }; 
            list.Add(item); 
        }
        ViewBag.roleList = (IEnumerable<SelectListItem>)list; 
        return View();
     }
    }
