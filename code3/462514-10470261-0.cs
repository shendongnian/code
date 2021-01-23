    private object GetPic()
    {
        if(pictureboxstupic.Image == null)
        {
            return null;
        }
        using (var stream = new MemoryStream())
        {
            var bmp = new Bitmap(pictureboxstupic.Image);
            bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            stream.Position = 0;
            var data = new byte[stream.Length];
            stream.Read(data, 0, data.Length);
            return data;
    
        }
    }
