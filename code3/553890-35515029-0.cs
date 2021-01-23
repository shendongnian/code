    List<decimal> MovingAverage(int period, decimal[] Data)
    {
         decimal[] interval = new decimal[period];
         List<decimal> MAs = new List<decimal>();
         for (int i=0, i < Data.length, i++)
         {
              interval[i % period] = Data[i];
              if (i > period - 1)
              {
                   MAs.Add(interval.Average());
              }
         }
         return MAs;
    }
