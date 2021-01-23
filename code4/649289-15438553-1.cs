    HttpFileCollection fileCollection = Request.Files;
    List<byte[]> imgs = new List<byte[]>();
    for (int i = 0; i < fileCollection.Count; i++)
    {
        HttpPostedFile uploadfile = fileCollection[i];
        byte[] imageBytes = new byte[uploadfile.InputStream.Length];
        uploadfile.InputStream.Read(imageBytes, 0, imageBytes.Length);
        if(imageBytes.Length > 0)
           imgs.Add(imageBytes);
    }
