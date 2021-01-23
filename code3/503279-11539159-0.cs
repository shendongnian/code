    public void DrawData(PointF[] points)
    {
        var bmp = Graph.Image;
        using(var g = Graphics.FromImage(bmp)) {
            g.DrawCurve(_penAxisMain, points);
        }
    }
