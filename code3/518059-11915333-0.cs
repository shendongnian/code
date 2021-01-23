    // Defined elsewhere
    struct Coord
    {
        public int x;
        public int y;
    }
    // Where you're doing your work...
    var intCoords = new List<Coord>();
    foreach (var coord in boardObjectList)
    {
        var str = coord.Split(new char[] { ' ' });
        intCoords.Add(new Coord() { 
            x = Int32.Parse(str[0]), 
            y = Int32.Parse(str[1])
        });
    }
    // Do the actual sort. Ensure you assign the result to a variable
    var newCoords = intCoords.OrderBy(x => x.x).ThenBy(x => x.y).ToList();
