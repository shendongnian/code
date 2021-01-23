    Random random = new Random((int)(DateTime.Now.ToBinary() % Int32.MaxValue));
    List<Card> hand = new List<Card>();
    
    for(int i = (int)CARDS.Five;i <= (int)CARDS.Nine;i++)
    {
        SUIT suit = (SUIT)(random.Next(4)+1);
        hand.Add(new Card { Suit = suit, Val = (CARDS)i });
    }
