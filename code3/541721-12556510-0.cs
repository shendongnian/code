    public class Card<TCard>
        where TCard : Card<TCard>
    {
        public Deck<TCard> OwningDeck { get; set; }
    }
