    pictureBox.Image = GetImage();
    
    public Image GetImage()
    {
        Image image;
        using (FileStream fs = File.OpenRead(@"C:\picture.jpg"))
        {
            long length = fs.Length;
    
            byte[] bytes = new byte[length];
    
            for (int pos = 0; pos < length; )
                pos += fs.Read(bytes, pos, (int)length - pos);
    
            fs.Position = 0;
    
            using (MemoryStream ms = new MemoryStream(bytes))
                image = Image.FromStream(ms);
        }
    
        return image;
    }
