    var deck = new Deck();
    
    var player = new List<Card>();
    var computer = new List<Card>();
    
    for(int index = 0; index < 52; index++)
    {
      if(index % 2 == 0)
      {
        player.Add(deck.GetCard());
      }
      else
      {
        computer.Add(deck.GetCard());
      }
    }
