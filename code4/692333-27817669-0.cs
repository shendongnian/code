    HttpPostedFile file = null;
    file = Request.Files[0]
    if (file != null && file.ContentLength > 0)
    {
    System.IO.Stream fileStream = file.InputStream;
    fileStream.Position = 0;
    byte[] fileContents = new byte[file.ContentLength];
    fileStream.Read(fileContents, 0, file.ContentLength);
    System.Drawing.Image image = System.Drawing.Image.FromStream(new System.IO.MemoryStream(fileContents));
    image.Height.ToString(); 
    }
