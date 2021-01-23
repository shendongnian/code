    var split = segment.Split();
    var coordinates = new List<Coordinate>(split.Length);
    foreach(string s in split)
    {
        coordinates.Add(new Coordinate(s));
    }
