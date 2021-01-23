    Bitmap bitmap = new Bitmap(i1.Width + i2.Width, 1080);
    using (Graphics g = Graphics.FromImage(bitmap))
    {
        g.DrawImage(i1, 0, 0);
        g.DrawImage(i2, i2.Width, 0);
        bitmap.Save(@"C:\TEST\Image_"+i.ToString()); 
    }
                     
