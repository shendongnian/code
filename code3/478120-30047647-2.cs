    Bitmap bImage = newImage;  //Your Bitmap Image
    System.IO.MemoryStream ms = new System.IO.MemoryStream();
    bImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
    byte[] byteImage = ms.ToArray();
    var SigBase64= Convert.ToBase64String(byteImage); //Get Base64
