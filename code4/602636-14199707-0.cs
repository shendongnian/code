    public ActionResult BControllerAction()
    {
         try{Something();}
         catch(SomethingException ex)
         {
             return RedirectToAction("AControllerAction", "AController", new { errorMessage = ex.Message() })
         }
    }
