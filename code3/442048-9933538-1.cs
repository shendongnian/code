    public class Deck
    {
        private List<PlayingCard> cards = new List<PlayingCard>();
        public Deck()
        {
            for(var i = 0; i < 4; i++)
            {
                for (var j = 1 to 13)
                {
                    this.cards.Add(new PlayingCard((CardSuit)i, (CardFace)j));
                }
            }
        }
        public void Shuffle() { /* implement me */ }
        public PlayingCard GetNextCard() { /* implement me */ }
    }
