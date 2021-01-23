    [RedirectFilterAttribute ]
    public ActionResult MyCatAction()
    {
         if(MyService.IsCat==false)
            return RedirectToAnotherControllerAction();
         ...
    }    
