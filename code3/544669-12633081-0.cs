    public static Deck FromType(String type)
    {
        if (type.Equals("Standard", StringComparison.OrdinalIgnoreCase))
        {
            return new Deck(type, 60);
        }
        else if (type.Equals("Extended", StringComparison.OrdinalIgnoreCase))
        {
            return new Deck(type, 60);
        }
        else if (type.Equals("Modern", StringComparison.OrdinalIgnoreCase))
        {
            return new Deck(type, 60);
        }
        else if (type.Equals("Commander", StringComparison.OrdinalIgnoreCase)|| type.Equals("EDH", StringComparison.OrdinalIgnoreCase))
        {
            return new Deck(type, 100);
        }
        throw new ArgumentOutOfRangeException("Bad type");
    }
