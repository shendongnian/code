    var deck = new List<Card>();
    cards.ForEach(c => 
    {
        for(int i = 0; i < c.AttributionRate; i++)
        {
             deck.Add(c);
        }
    }
