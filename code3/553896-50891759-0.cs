      // n is the window for your Simple Moving Average
      public List<double> GetMovingAverages(List<Price> prices, int n)
      {
        var movingAverages = new double[prices.Count];
        var runningTotal = 0.0d;       
        
        for (int i = 0; i < prices.Count; ++i)
        {
          runningTotal += prices[i].Value;
          if( i - n >= 0) {
            var lost = prices[i - n].Value;
            runningTotal -= lost;
            movingAverages[i] = runningTotal / n;
          }
        }
        return movingAverages.ToList();
      }
