    [HttpPost]
    public ActionResult Create(tblPortfolio tblportfolio) 
    {
     if(Request.Files.Count > 0)
     {
     HttpPostedFileBase file = Request.Files[0];
     if (file != null) 
     { 
      // business logic here  
     }
     } 
    }
