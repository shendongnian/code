    [HttpPost]
    public ActionResult Register(RegisterViewModel objVM)
    {
      if(ModelState.IsValid)
      {
        //Check your custom validation also
        if (createStatus == MembershipCreateStatus.Success)
        {
              //Save and then Redirect
    
        }
        else
        {
          objVM.Roles=GetAllRolesAs(); // get the list of roles here again because HTTP is stateless
        }
      }  
     return View(objVM);
    }
