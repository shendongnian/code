    Bitmap bImage = newImage;  // Your Bitmap Image
    System.IO.MemoryStream ms = new MemoryStream();
    bImage.Save(ms, ImageFormat.Jpeg);
    byte[] byteImage = ms.ToArray();
    var SigBase64= Convert.ToBase64String(byteImage); // Get Base64
