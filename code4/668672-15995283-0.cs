    using System;
    class Program {
      static void Main() {
        int? X;
        X = 1;
        X = default(int?);
    
        Console.WriteLine(X.HasValue);
      }
    }
