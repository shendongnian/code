    Random random = new Random((int)(DateTime.Now.ToBinary() % Int32.MaxValue));
    List<Card> hand = new List<Card>();
    
    for(int card = (int)CARDS.Five;card <= (int)CARDS.Nine;card++)
    {
        SUIT suit = (SUITS)(random.Next(4)+1);
        hand.Add(new Card { Suit = suit, Val = (CARDS)card });
    }
