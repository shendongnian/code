     int[] ints1 = { 1, 2, 3 }; int[] ints2 = { 3, 4, 5 };
     IEnumerable<INT> union = ints1.Union(ints2);
     Console.WriteLine("Union");
     foreach (int num in union)
     {
        Console.Write("{0} ", num);
     }
     Console.WriteLine();
     IEnumerable<INT> concat = ints1.Concat(ints2);
     Console.WriteLine("Concat");
     foreach (int num in concat)
     {
        Console.Write("{0} ", num);
     } 
