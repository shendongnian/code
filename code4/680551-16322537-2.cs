    public IEnumerable<IEnumerable<int>> getCoins(int price)
    {
       int[] coinValues = new int[] { 1, 2, 5, 10, 20, 50, 100, 200 }; // Coin values
       if (coinValues.Contains(price))
          yield return new int[] { price }; // If the price can be represented be a single coin
       // For every coin that is smaller than the price, take it away, call the function recursively and concatenate it later
       foreach (int coin in coinValues.Where(x => x < price))
          foreach (IEnumerable<int> match in getCoins(price - coin))
             if (match.Min() >= coin)
                yield return match.Concat(new int[] { coin });
    }
