    Card GetCard(List<Card> cards)
    {
      int total = 0;
      foreach (Card c in cards)
      {
        total += AttributionRate;
      }
      
      int index = Random.Next(0, total - 1);
      foreach(Card c in cards)
      {
        index -= c.AttributionRate;
        if (index < 0)
        {
          return c;
        }
      }
    }
    Card PopCard(List<Card> cards)
    {
      Card c = GetCard(cards);
      cards.Remove(c);
    }
