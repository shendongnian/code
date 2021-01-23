    public ActionResult HomeAction()
    {
       HomeVM objHomeVM = new HomeVM();
       BusinessMethod(objHomeVM);
       return View(objHomeVM);
    }
    public ActionResult HomeChildAction()
    {
       HomeChildVM objHomeChildVM = new HomeChildVM();
       BusinessMethod(objHomeChildVM);
       return View(objHomeChildVM);
    }
    private void BusinessMethod(HomeVM objHomeVM)
    {
       ...
    }
