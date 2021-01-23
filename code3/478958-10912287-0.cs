    public ActionResult downloadFile()
    {
        var path = "somename.htm";
        StreamReader reader = new StreamReader(path);
        var fileBytes = System.IO.File.ReadAllBytes(path);            
        FileContentResult file = File(fileBytes, "text/html");
        return file;
    }
