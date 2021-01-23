    public ActionResult AddTag()
    {
        var vm = new MyModel();
        vm.Tags.Add(new Tag { Name = "Test1" });
        vm.Tags.Add(new Tag { Name = "Test2" });
        return View(vm);
    }
