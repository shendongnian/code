    private bool UploadFile(string tempFolder, HttpPostedFileBase file)
    {
       var path = Path.Combine(tempFolder, file.FileName);
    
       // if the file does not exist, save it.
       if (!File.Exists(path))
       {
          file.SaveAs(path);
          return true;
       }
    
       return false;
    }
