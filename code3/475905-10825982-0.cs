    public ActionResult Save(long id, string whichForm)
    {
        if (whichForm == "A")
        {
            var vm = new FormAViewModel();
    
            if (!TryUpdateModel(vm))
                return View(vm);
            else
                return RedirectToRoute("Success");
        }
        else ....
    }
