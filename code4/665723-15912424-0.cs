    public Deck(bool deckHasCards, IEnumerable<Card> cards)
    {
        foreach (Card c in cards)
            this.Add(c);
    }
