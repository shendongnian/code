    [HttpPost]
    public ActionResult Create(FormCollection collection)
    {
       HttpPostedFileBase file = Request.Files["ProductAvatar"];
    
       if (file.ContentLength > 0)
       {
          file.SaveAs(/* path */);
       }
    
       // othyer tasks
    
       return RedirectToAction("Index");
    }
