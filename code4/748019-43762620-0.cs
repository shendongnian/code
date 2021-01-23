    // byte[] fileBytes = getFileBytesFromDB();
    var tmpFile = Path.GetTempFileName();
    File.WriteAllBytes(tmpFile, fileBytes);
    
    Application app = new word.Application();
    Document doc = app.Documents.Open(filePath);
    
    // .. do your stuff here ...
    
    doc.Close();
    byte[] newFileBytes = File.ReadAllBytes(tmpFile);
    File.Delete(tmpFile);
