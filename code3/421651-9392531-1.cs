    System.IO.MemoryStream ms = new System.IO.MemoryStream();
    
    if (images.Count > 0)
    {
        int totalHeight = 0;
        int maxWidth = 0;
        for (int i = 0; i< images.count; i++)
        {
            totalHeight += images[i].Height;
            if (images[i].Width > maxWidth)
            {
                maxWidth = images[i].Width;
            }
        } 
        Image mergedImage = new System.Drawing.Bitmap(maxWidth, totalHeight);
        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(mergedImage);
        int heightOffset = 0;
        for (int i = 0; i< images.Count; i++)
        {
            g.DrawImage(images[i],new Point(0, heightOffset));
            heightOffset += images[i].Height;
        }
        g.Dispose(); // Mandatory! Graphics is using unmanaged resources so it must be disposed explicitly.
        mergedImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
    }
