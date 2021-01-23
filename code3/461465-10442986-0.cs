     public ActionResult clipstore(string id)
        {
            var path = GetFilePathByID(id);
            StreamReader reader = new StreamReader(path);
            var fileBytes = System.IO.File.ReadAllBytes(path);            
            
            FileContentResult file = File(fileBytes, "image/png");
            return file;
        }
    
