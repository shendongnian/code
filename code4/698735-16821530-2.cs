    [HttpPost]
    public ActionResult FileUploadCreate(NonProject myRecord)
    {
        string path = "";
                  
        if (myRecord.PDF != null)
        {
            if (myRecord.PDF.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(myRecord.PDF.FileName);
                    string directory = "c:\\temp\\Accruals\\PDF";
                    path = Path.Combine(directory, fileName);
                    myRecord.PDF.SaveAs(path);
                }
        }
        try
        {
            _repository.AddNonProject(myRecord);
            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
        return RedirectToAction("Index");
    }
