    class CalController 
    {
     public ActionResult Home()
     {
      return View("~/Views/Folder1/view.cshtml");
      //OR
      return View("~/Views/Folder2/view.cshtml");
     }
    }
    
