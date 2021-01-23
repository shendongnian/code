    using (var ms = new MemoryStream())
    {
       camPictureBox.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
    
       using (var bitmap = new Bitmap(ms))
       {
           // do your work
       }
    }
