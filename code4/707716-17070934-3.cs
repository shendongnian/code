    public enum Suit
    {
        Clubs,
        Diamonds,
        Hearts,
        Spades
    }
    public enum Rank
    {
        Ace = 1,
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }
    public class Card: IEquatable<Card>
    {
        public Rank Rank
        {
            get; 
            set;
        }
        public Suit Suit
        {
            get; 
            set;
        }
        public int Value
        {
            get
            {
                switch (Rank)
                {
                    case Rank.Ten:
                    case Rank.Jack:
                    case Rank.Queen:
                    case Rank.King:
                        return 10;
                    default:
                        return (int) Rank;
                }
            }
        }
    }
