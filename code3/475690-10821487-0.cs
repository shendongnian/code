    public enum CardColor
    {
      Hearts = 0,
      Diamonds = 1,
      Clubs = 2,
      Spades = 3
    }
    
    public enum CardValue
    {
      Ace = 1,
      Two,
      Three,
      Four,
      Five,
      Six,
      Seven,
      Eight,
      Nine,
      Ten,
      Jack,
      Queen,
      King
    }
    
    public class Card
    {
      public Card(CardValue value, CardColor color)
      {
        Value = value;
        Color = color;
      }
    
      public readonly CardValue Value;
      public readonly CardColor Color;
    }
    
    public class Deck
    {
      private Queue<Card> deckInternal;
    
      public Deck()
      {
        var deck = new List<Card>();
        for(int index = 0; index < 52; index++)
        {
          var cardValue = (CardValue)(index % 4) + 1;
          var cardColor = (CardColor)index / 4;
          dec.Add(new Card(cardValue, cardColor));
        }
    
        var rand = new Random();
        dec = dec
          .OrderBy(c => rand.Next(52))
          .ToList();
    
        deckInternal = new Queue<Card>(deck);
      }
    
      public Card GetCard()
      {
        return deckInternal.Dequeue();
      }
    }
