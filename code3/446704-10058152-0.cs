    while ( Deck.NumCards >= 2 )
    {
       Card card1 = Deck.GetACard();
       Card card2 = Deck.GetACard();
       PrintSomeStuffAboutACard( GetWinner( card1, card2 ) );
    }
