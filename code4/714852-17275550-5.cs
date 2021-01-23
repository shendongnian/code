    public enum Suit
    {
        Spades,
        Clubs,
        Diamonds,
        Hearts
    }
    public enum Rank
    {
        Ace   = 1,
        Two   = 2,
        Three = 3,
        Four  = 4,
        Five  = 5,
        Six   = 6,
        Seven = 7,
        Eight = 8,
        Nine  = 9,
        Ten   = 10,
        Jack  = 11,
        Queen = 12,
        King  = 13
    }
    class Card
    {
        readonly Suit _suit;
        readonly Rank _rank;
        public Card(Suit suit, Rank rank)
        {
            _suit = suit;
            _rank = rank;
        }
        public Rank Rank
        {
            get
            {
                return _rank;
            }
        }
        public Suit Suit
        {
            get
            {
                return _suit;
            }
        }
        public int Value
        {
            get
            {
                if (Rank >= Rank.Ten)
                {
                    return 10;
                }
                else
                {
                    return (int) Rank;
                }
            }
        }
        public override string ToString()
        {
            return _rank + " of " + _suit + " with value " + Value;
        }
    }
