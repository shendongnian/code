    System.Drawing.Image image;
    System.IO.MemoryStream imageStream;
    byte[] imageBytes;
    // image = your image object
    imageStream = new System.IO.MemoryStream();
    image.Save(imageStream, System.Drawing.Imaging.ImageFormat.Jpeg); // Use whatever format your image is.
    imageBytes = imageStream.ToArray();
    // Save imageBytes to a DB column of type VARBINARY(MAX)
