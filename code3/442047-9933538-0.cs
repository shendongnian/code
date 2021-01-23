    publlic class PlayingCard
    {
        internal PlayingdCard(CardSuit suit, CardFace face)
        {
            this.Suit = suit;
            this.Face = face;
        } 
        public CardSuit Suit { get; private set; }
        public CardFace Face { get; private set; }
    }
