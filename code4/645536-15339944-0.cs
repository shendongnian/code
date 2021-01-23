    [HttpPost]
    public ActionResult Upload(HttpPostedFileBase myFile)
    {
        if (myFile != null && myFile.ContentLength > 0) 
        {
            var fileName = Path.GetFileName(myFile.FileName);
            var path = Path.Combine(Server.MapPath("~/App_Data"), fileName);
            myFile.SaveAs(path);
        }    
    
        ...
    }
