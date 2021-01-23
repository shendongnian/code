    public ActionResult ConfirmUser()
    {
        var vm = new ConfirmUserViewModel();
    
        //The below code is hardcoded for demo. you mat replace with DB data.
        vm.ReportedUsers.Add(new ReportedUserViewModel { Name = "Test1" , Id=1});
        vm.ReportedUsers.Add(new ReportedUserViewModel { Name = "Test2", Id=2 });
    
        return View(vm);
    }
