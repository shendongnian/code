     var l = new List<int>();
     for (int i = 1; i <= Math.Max(num1, num2); i++) {
      if (num1 >= i) {
       l.Add(-1 * i);
      }
      if (num2 >= i) {
       l.Add(i);
      }
     }
     foreach (int num in l) {
      System.Console.WriteLine(num);
     }
