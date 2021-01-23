    public ActionResult CreateUser()
    {
        var vm = new UserViewModel();
        //The below code is hardcoded for demo. you mat replace with DB data.
        vm.UserGroups= new[]
        {
          new SelectListItem { Value = "1", Text = "Group 1" },
          new SelectListItem { Value = "2", Text = "Group 2" },
          new SelectListItem { Value = "3", Text = "Group 3" }
        };  
        return View(vm);
    }
