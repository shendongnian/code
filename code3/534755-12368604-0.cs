    private Image GetCake(int width, int height, double percentage)
    {
        var bitmap = new Bitmap(width, height);
        using (var g = Graphics.FromImage(bitmap))
        {
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.FillEllipse(Brushes.DarkMagenta, 1, 9, width - 2, height - 10);
            g.DrawEllipse(Pens.Black, 1, 9, width - 2, height - 10);
            g.FillPie(Brushes.DarkBlue, 1, 9, width - 2, height - 10, 0, (int)(360 * percentage));
            g.DrawPie(Pens.Black, 1, 9, width - 2, height - 10, 0, (int)(360 * percentage));
            g.FillEllipse(Brushes.Magenta, 1, 1, width - 2, height - 10);
            g.DrawEllipse(Pens.Black, 1, 1, width - 2, height - 10);
            g.FillPie(Brushes.Blue, 1, 1, width - 2, height - 10, 0, (int)(360 * percentage));
            g.DrawPie(Pens.Black, 1, 1, width - 2, height - 10, 0, (int)(360 * percentage));
            g.DrawArc(Pens.Blue, 1, 1, width - 2, height - 10, 0, (int)(360 * percentage));
        }
        return bitmap;
    }
