    // first define the possible values
    var suits = new [] {"red", "blue", "diamond", "candy"};
    var ranks = new [] {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "farmer", "queen", "king"}
    
    //var ranks = Enumerable.Range(1, 10).Select(n => n.ToString())
    //                      .Concat(new [] {"farmer", "queen", "king"})
    //                      .ToArray();
    
    // given the known values, you just iterate over every possible index
    for(int i = 0; i < suits.Length * ranks.Length; i++)
    {
        Cardgame[i] = new CardGame();
        Cardgame[i].CardColor = suits[i % suits.Length];
        Cardgame[i].Number = ranks[i / ranks.Length];
    }
    
    // or some "harder" LINQ    
    var Cardgame = (from s in suits
                   from r in ranks
                   select new CardGame(s, r)).ToArray();
