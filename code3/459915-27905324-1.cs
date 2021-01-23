    [HttpPost] public ActionResult Create(tblPortfolio tblportfolio)
    { 
     for(int i=0; i < Request.Files.Count; i++)
     {
       HttpPostedFileBase file = Request.Files[i];
       if (file != null)
       {
        // Do something here
       }
     }
    }
