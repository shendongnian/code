    [HttpPost]
    public FilePathResult FileToFasta(F2FModel model)
    {
        string FullText = new StreamReader(model.File.InputStream).ReadToEnd();
        TextLayer layer = new TextLayer(FullText);
        string outputFile = layer.WriteToFasta();
    
        string mydatetime = DateTime.Now.ToString("MMddyyyy");
        string FileName = String.Format("TextFile{0}.txt", mydatetime);
    
        //Use different encoding if needed
        byte[] outputArray = Encoding.Unicode.GetBytes(outputFile);
        MemoryStream outputStream = new MemoryStream(outputArray); 
    
        //FileStreamResult will close the stream for you so don't worry
        return new FileStreamResult(outputStream, "text/plain") { FileDownloadName = FileName };
    }
