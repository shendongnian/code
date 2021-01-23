    Response.Clear();
    Response.ContentType = "image/jpeg";
    using (System.Drawing.Image returnImage = System.Drawing.Image.FromFile(completeImageFilePath))
    {
        using (MemoryStream stream = new MemoryStream())
        {
            returnImage.Save(stream, ImageFormat.Jpeg);
            stream.WriteTo(Response.OutputStream);
        }
    }
    if (Response.IsClientConnected)
    {
        Response.Flush();
    }
    Response.End();
