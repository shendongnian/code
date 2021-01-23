    [HttpPost]
    public ActionResult Upload(IEnumerable<HttpPostedFileBase> files)
    {
        if (files != null && files.Count() > 0)
        {
            foreach (var uploadedFile in files)
            {
                if (uploadedFile.ContentType != "image/vnd.dwg") 
                {
                    return RedirectToAction("List");
                }
                var appData = Server.MapPath("~/app_data");
                var filename = Path.Combine(appData, Path.GetFileName(uploadedFile.FileName));
                uploadedFile.SaveAs(filename);                    
            }
        }
        return RedirectToAction("Success");
    }
