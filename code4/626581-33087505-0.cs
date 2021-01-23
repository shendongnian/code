    public FileResult Download(string fileName)
    {
       if (string.IsNullOrEmpty(fileName) || !File.Exists(fileName))
       {
           ViewBag.Error = "Invalid file name or file path";
           RedirectToAction("Index");
       }
       // rest of the code
    }
