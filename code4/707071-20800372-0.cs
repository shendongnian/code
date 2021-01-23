    public class Card
    {
        public Card(Rank rank, Suite suite)
        {
            this.Rank = rank;
            this.Suite = suite;
            this.IsFaceUp = true;
        }
        public Rank Rank { get; private set; }
        public Suite Suite { get; private set; }
        public bool IsFaceUp { get; private set; }
        public void Flip()
        {
            this.IsFaceUp = !this.IsFaceUp;
        }
    }
    public enum Rank : byte
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
        King  = 13,
    }
    public enum Suite : byte
    {
        Club    = 1,
        Diamond = 2,
        Heart   = 3,
        Spades  = 4
    }
