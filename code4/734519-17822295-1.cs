    public ActionResult XXX()
    {
        var vm=new MyViewModel(); //or just use ViewBag/ViewData
    #if (DEBUG)
        vm.RunJS=true;
    #else
        vm.RunJS=false;
    #endif
        return View(vm);
    }
