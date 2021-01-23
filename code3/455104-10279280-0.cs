    public Coordinates(string x, string y)
    {
        X = x;
        Y = y;
    }
    public string X { get; private set; }
    public string Y { get; private set; }
    public override bool Equals(object obj)
    {
        if (!(obj is Coordinates))
        {
            return false;
        }
        Coordinates coordinates = (Coordinates)obj;
        return ((coordinates.X == this.X) && (coordinates.Y == this.Y));
    }
