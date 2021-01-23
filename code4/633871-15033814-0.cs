    Bitmap bmp = new Bitmap(50, 50, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
    using (Graphics g = Graphics.FromImage(bmp))
    {
        g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
        g.FillRectangle(Brushes.Black, 0, 0, 50, 50);
        g.FillEllipse(Brushes.Transparent, 25, 0, 25, 25);
        g.DrawLine(Pens.Transparent, 0, 0, 50, 50);
        g.Flush();
    }
    bmp.Save("Test.bmp");
