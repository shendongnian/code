    public class Deck
    {
        ...
        public Deck(IEnumerable<Card> cards) { ... Shuffle() ... }        
        public void DealTo(IDealable dealable, int numberOfCards) {...}
    }
