    struct Card
    {
        public int number;
        public CardType type;
        public Card(int number, CardType type)
        {
            this.number = number;
            this.type = type;
        }
    }
    enum CardType
    {
        Diamonds,
        Spades,
        Hearts,
        Clubs
    }
