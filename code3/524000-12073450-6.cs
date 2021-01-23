    public ActionResult AddTag()
    {
        var vm = new MyModel();
        //The below code is hardcoded for demo. you mat replace with DB data.
        vm.Tags.Add(new Tag { Name = "Test1" });
        vm.Tags.Add(new Tag { Name = "Test2" });
        return View(vm);
    }
