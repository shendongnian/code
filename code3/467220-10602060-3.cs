    double x, y;
    while ((line = reader.ReadLine()) != null)
    {
        if tryParseCoordinates(line, out X, out Y)
        {
            // Do something with X and Y like 
            // making a genuine Coord out of them or adding them to a list
        }
    }
