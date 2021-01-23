    bool tryParseCoordinates(string line, out double X, out double Y)
    {
        var coords = line.Split(new char[] { '\t' }, System.StringSplitOptions.RemoveEmptyEntries);
        return (coords.Length == 2 && double.TryParse(coords[0], out X) && double.TryParse(coords[1], out Y));
    }
