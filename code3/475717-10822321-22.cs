            var d = new Deck();
            Deck.Card c = 0; //Joker Of Spades(0)
            c = 1; //Joker Of Clubs (0)
            c = 4; //Ace Of Spades (1)
            c = 52; //King Of Spades (13)
            d.Shuffle();
            d.Take(1);
            d.TakeRandom(1);
            d.Cards.Skip(10).Take(5);
