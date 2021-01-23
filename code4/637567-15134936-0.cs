    using (Bitmap bmp = new Bitmap(width, height))
    {
        using (Graphics g = Graphics.FromImage(bmp))
        {
            g.CopyFromScreen(x, y, 0, 0, bmp.Size, CopyPixelOperation.SourceCopy);
        }
        // do whatever with `bmp`
    }
