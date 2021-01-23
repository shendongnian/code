    private List<Card> NewDeck(Suit CardSuit, FaceValue CardValue, int iValue)
    {
       for (int i = 0; i <= 3; i++) 
       {
           for (int j = 0; j <= 12; j++) 
           {
               Card newCard = new Card(AllSuit [i], AllFaces[j], iValue[j]);
           }
       }
    }
     var AllSuit = new Suit[]
        {
          Suit.Spades,
          Suit.Hearts,
          Suit.Clubs,
          Suit.Diamonds
        };
        
        //Do the same for AllFaces...
