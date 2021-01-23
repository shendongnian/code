    public ActionResult XXX()
    {
        var vm=new MyViewModel();
    #if (DEBUG)
        vm.RunJS=true;
    #else
        vm.RunJS=false;
    #endif
        return View(vm);
    }
