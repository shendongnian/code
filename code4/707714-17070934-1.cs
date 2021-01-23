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
        public bool Equals(Card other)
        {
            if (other == null)
                return false;
            else
                return (this.Rank == other.Rank) && (this.Suit == other.Suit);
        }
    }
