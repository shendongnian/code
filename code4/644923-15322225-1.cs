    [HttpPost]
    public ActionResult UploadFile(HttpPostedFileBase myFile)
    {
        var path = string path = @"D:\Temp\";
        myFile.SaveAs(Path.Combine(path, myFile.FileName));
        return PartialView();
    }
