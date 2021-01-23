    //get image from file or smth.
    Image img = Image.FromFile(filename);
     
    byte[] bytes;
    using (MemoryStream ms = new MemoryStream())
    {
        img.Save(ms, ImageFormat.Tiff);
        bytes = ms.ToArray();
    }
    string ret = Convert.ToBase64String(bytes);
    return ret;
