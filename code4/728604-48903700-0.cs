    byte[] bytes = System.Convert.FromBase64String(base64ImageString);
    using (MemoryStream ms = new MemoryStream(bytes))
    {
        var image = Image.FromStream(ms);
        image.Save(filePath, System.Drawing.Imaging.ImageFormat.Png);
    }
