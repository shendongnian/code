    [HttpPost]
    public ActionResult File_post(HttpPostedFileBase file)
    {
       if (...) 
       {
          return View("Success");
       }
       else
       {
          Response.StatusCode = 500;
          Response.TrySkipIisCustomErrors = true; 
          return View("Error");
       }
    }
