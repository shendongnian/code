     public ActionResult Add(HttpPostedFileBase file)
    {
       string extension = Path.GetExtension(file.FileName);
       using (Stream stream = file.InputStream)
       {
            // Save your stream to Disk or database as you need
       }
                    
    }
