    List<Card> deck = new List<Card>();
    deck.Add(new Card {Rank = Rank.Seven, Suit = Suit.Clubs} ); 
    deck.Add(new Card {Rank = Rank.Five,  Suit = Suit.Diamonds} );
    Card target1 = new Card {Rank = Rank.Five,  Suit = Suit.Diamonds };
    Card target2 = new Card {Rank = Rank.Eight, Suit = Suit.Hearts };
    Console.WriteLine(deck.Contains(target1)); // Prints true
    Console.WriteLine(deck.Contains(target2)); // Prints false
    Console.WriteLine(deck.IndexOf(target1)); // Prints 1
