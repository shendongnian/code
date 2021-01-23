        public IEnumerable<IEnumerable<int>> getCoins(int price, int MaxCoin = 200)
        {
            int[] coinValues = new int[] { 1, 2, 5, 10, 20, 50, 100, 200 }.Reverse().ToArray(); // Coin values
            foreach (int coin in coinValues.Where(x => x <= price && x <= MaxCoin))
            {
                if (coin == price)
                {
                    yield return new int[] { price }; // If the price can be represented be a single coin
                }
                else
                {
                    foreach (IEnumerable<int> match in getCoins(price - coin, coin))
                    {
                        yield return new int[] { coin }.Concat(match);
                    }
                }
            }
        }
