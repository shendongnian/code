    public static Bitmap Draw(this IEnumerable<Point> points, 
                              Color paintColor = default(Color))
    {
        return points.Draw(paintColor, Color.White);
    }
    public static Bitmap Draw(this IEnumerable<Point> points, Color paintColor, 
                              Color backColor)
    {
        return points.Draw(paintColor, backColor, (ps, leftmost, topmost) => ps);
    }
    public static Bitmap DrawRelative(this IEnumerable<Point> points,
                                      Color paintColor = default(Color))
    {
        return points.DrawRelative(paintColor, Color.White);
    }
    public static Bitmap DrawRelative(this IEnumerable<Point> points,
                                      Color paintColor, Color backColor)
    {
        return points.Draw(paintColor, backColor, 
                           (ps, leftmost, topmost) => ps.Select(p => new Point(p.X - leftmost.X, p.Y - topmost.Y)));
    }
    static Bitmap Draw(this IEnumerable<Point> points, 
                       Color paintColor, Color backColor, 
                       Func<IEnumerable<Point>, Point, Point, IEnumerable<Point>> transformer)
    {
        points = points.ToArray();
        Func<IEnumerable<Point>, IEnumerable<Point>> horizontallSorter = ps => ps.OrderBy(p => p.X);
        Func<IEnumerable<Point>, IEnumerable<Point>> verticallSorter = ps => ps.OrderBy(p => p.Y);
        var leftmost = horizontallSorter(points).First();
        var topmost = verticallSorter(points).First();
        var relativePoints = transformer(points, leftmost, topmost).ToArray();
        var rightmost = horizontallSorter(relativePoints).Last();
        var bottommost = verticallSorter(relativePoints).Last();
        var img = new Bitmap(rightmost.X + 1, bottommost.Y + 1);
        using (var g = Graphics.FromImage(img))
        {
            g.Clear(backColor);
        }
        foreach (var item in relativePoints)
            img.SetPixel(item.X, item.Y, paintColor);
        return img;
    }
