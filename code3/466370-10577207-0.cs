        var ms = new MemoryStream();
        Rectangle bounds = Screen.GetBounds(Point.Empty);
        using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.CopyFromScreen(Point.Empty, Point.Empty, bitmap.Size);
            }
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
        }
