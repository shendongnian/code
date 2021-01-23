    void Main()
    {
        Hand hand = new Hand();
        foreach( var card in hand.Cards() )
        {
            Console.WriteLine("{0}", card);
        }
	
        var allCards = hand.Cards();
        foreach( var anotherCard in allCards )
        {
            Console.WriteLine("{0}", anotherCard);
        }
    }
    public class Card
    {
	private string _cardName;
	public Card( string cardName )
        {
            this._cardName = cardName;
        }
	
        public override string ToString()
        {
            return this._cardName;
        }
    }
    public class Hand
    {
        public IEnumerable<Card> Cards()
        {
            yield return new Card("Ace");
            yield return new Card("King");
        }
    }
