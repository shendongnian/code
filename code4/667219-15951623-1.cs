    public ActionResult Create()
    {
      var vm=new CreateIssueVM();
      vm.Priorities =GetPriorities();
      return View(vm);
    }
