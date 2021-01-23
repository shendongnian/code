    [HttpPost]
    public ActionResult Index(HttpPostedFileBase file)
    {
        if (file != null && file.ContentLength > 0) 
        {
            //file handling logic
            file.SaveAs(/* your path here */);
        }
        return RedirectToAction("Index");        
    }
