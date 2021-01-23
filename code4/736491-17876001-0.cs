    public static BitmapImage base64image(string base64string)
    {
        byte[] fileBytes = Convert.FromBase64String(base64string);
        using (MemoryStream ms = new MemoryStream(fileBytes))
        {
            Image streamImage = Image.FromStream(ms);
            context.Response.ContentType = "image/jpeg";
            streamImage.Save(context.Response.OutputStream, ImageFormat.Jpeg);
            return streamImage;
        }
    }
