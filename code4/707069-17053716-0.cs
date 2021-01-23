    public class Card
    {
        public Suit Suit { get; private set; }
        public Rank Rank { get; private set; }
        public Card(Suit suit, Rank rank)
        {
             this.suit = suit;
             this.rank = rank;
        }
    } 
