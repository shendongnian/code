        public static int[] FillDeck()
        {
            var deck = new List<int>();
            // 0 = Ace , 12 = King : 0 = Hearts, 1 = Diamonds, 2 = Clubs, 3 = Spades
            for (int x = 0; x < 13; x++)
                for (int y = 0; x < 4; ++y)
                {
                    deck.Add(x + y);
                }
            return deck.ToArray();
        }
