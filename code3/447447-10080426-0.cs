    Coordinate[] result = segment
    .Split(';')
    .Select(s => s.Split(','))
    .Select(BuildCoordinate)
    .ToArray();
    Coordrinate BuildCoordinate(string[] coords)
    {
        if(coords.Length != 2)
            return null;
        return new Coordinate(double.Parse(a[0].Trim(), double.Parse(a[1]);
    }
