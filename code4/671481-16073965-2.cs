    // Do this in the controller and do the same ajax post
    public ActionResult TestContactView()
    {
        var vm = new TestContact();
        vm.Studio.Add(new TestContactItem(){Id=1, Name = "Studio Contact ID=1"});
        vm.Studio.Add(new TestContactItem(){Id=3, Name = "Studio Contact ID=3"});
        vm.StudioExecutive.Add(new TestContactItem() { Id = 2, Name = "Studio Exec Contact ID=2" });
        return View(vm);
     }
