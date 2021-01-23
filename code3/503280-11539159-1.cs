    public void DrawData(PointF[] points)
    {
        var bmp = Graph.Image;
        using(var g = Graphics.FromImage(bmp)) {
            // Probably necessary for you:
            g.Clear();
            g.DrawCurve(_penAxisMain, points);
        }
        Graph.Invalidate(); // Trigger redraw of the control.
    }
