    List<Point> plist = new List<Point>();
    for (int i = 0; i < list.Length; i += 2)
    {
        plist.Add(new Point(list[i], list[i + 1]));
    }
