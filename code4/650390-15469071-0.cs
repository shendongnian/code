    public class Hand
    {
        // You should make this private with a public property to guard it
        public List<Card> PlayerHand;
        // No reason to expose this to the outside
        private Deck cardDeck = new Deck();
        public Hand (Deck cards)
        {
            cardDeck = cards;
        }
        // There's nothing worth returning here, so make it void
        public void Hit()
        {
            // I would probably implement a method in the Deck class
            // so you could do something like (where RemoveNext returns the card removed):
            // playerHand.Add(cards.RemoveNext()); 
            playerHand.Add(CardDeck[1]);
            CardDeck.Remove(CardDeck[1]);
        }
