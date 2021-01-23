    using System;
    class P
    {
      static void Main()
      {
        decimal buckFifty = 1.50m;
        decimal buckFortyNine = 1.49m;
        Console.WriteLine(Math.Round(buckFortyNine, MidpointRounding.AwayFromZero));
        Console.WriteLine(Math.Round(buckFifty, MidpointRounding.AwayFromZero));
        Console.WriteLine(Math.Round(-buckFortyNine, MidpointRounding.AwayFromZero));
        Console.WriteLine(Math.Round(-buckFifty, MidpointRounding.AwayFromZero));
      }
    }
