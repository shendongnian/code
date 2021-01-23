    public ActionResult AddProgram()
    {
      var vm=new AddProgramViewModel();
     
      vm.ReminderList.Add(new SelectListItem { Value="0", Text="None"});
      vm.ReminderList.Add(new SelectListItem { Value="300", Text="5 minutes"});
      //Add more as needed
      //(you may get from DB and add instead of hard coding like this)
    }
