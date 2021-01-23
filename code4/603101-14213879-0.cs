    if (FileUpload1.HasFile)
    {
        var stream = FileUpload1.PostedFile.InputStream;
        byte[] byteData = new byte[FileUpload1.PostedFile.ContentLength];
        stream.Read(byteData, 0, byteData.Length);
        stream.Close();
    
        ...
