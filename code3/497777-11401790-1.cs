    // declaration
    List<Tuple<Vector2, Color>> markers = new List<Tuple<Vector2, Color>>();
    // adding items
    Tuple<Vector2, Color> marker = new Tuple<Vector2, Color>(
        new Vector2(x, y), Color.FromNonPremultiplied(250, 200, 150, 100));       
    markers.Add(marker);
    // retrieving item values
    foreach (var item in markers)
    {
        int x = item.Item1.X;
        int y = item.Item1.Y;
        Color mycolor = item.Item2;
    }
