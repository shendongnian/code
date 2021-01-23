    public enum Value
    {
        V2,
        V3,
        //...
        V10,
        J,
        Q,
        K,
        A
    }
    public enum Suit
    {
        Diamonds,
        Spades,
        Hearts,
        Clubs
    }
    public static bool ContainsCard(IEnumerable<Tuple<Suit,Value>> deck, Suit suit, Value value)
    {
        return deck.Any(c => c.Item1 == suit && c.Item2 == value);
    }
