cs
public string ImageToBase64(Image image, 
  System.Drawing.Imaging.ImageFormat format)
{
  using (MemoryStream ms = new MemoryStream())
  {
    // Convert Image to byte[]
    image.Save(ms, format);
    byte[] imageBytes = ms.ToArray();
    // Convert byte[] to Base64 String
    return Convert.ToBase64String(imageBytes);
  }
}
public Image Base64ToImage(string base64String)
{
    // Convert Base64 String to byte[]
    byte[] imageBytes = Convert.FromBase64String(base64String);
    using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
    {
        // Convert byte[] to Image
        ms.Write(imageBytes, 0, imageBytes.Length);
        return Image.FromStream(ms, true);
    }
}
