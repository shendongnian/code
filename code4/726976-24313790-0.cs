    using(var graph = Graphics.FromImage(image.Bitmap))
    {
        graph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        graph.DrawEllipse(new Pen(color.BackColor), x, y, d`i`ameter, diameter);
    }
`
