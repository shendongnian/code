    int[][] numbers = {
      new int[] { 14, 24, 44, 36, 37, 45 },
      new int[] { 01, 02, 06, 24, 33, 44 },
      new int[] { 10, 17, 34, 40, 44, 45 },
      new int[] { 12, 13, 28, 31, 37, 47 },
      new int[] { 01, 06, 07, 09, 40, 45 },
      new int[] { 01, 05, 06, 19, 35, 44 },
      new int[] { 13, 19, 20, 26, 31, 47 },
      new int[] { 44, 20, 30, 31, 45, 46 },
      new int[] { 02, 04, 14, 23, 30, 34 },
      new int[] { 27, 30, 41, 42, 44, 49 },
      new int[] { 03, 06, 15, 27, 37, 48 }
    };
    
    var count = new Dictionary<KeyValuePair<int, int>, int>();
    foreach (int[] row in numbers) {
      foreach (int i in row) {
        foreach (int n in row.Where(n => n > i)) {
          KeyValuePair<int, int> key = new KeyValuePair<int, int>(i, n);
          if (count.ContainsKey(key)) {
            count[key]++;
          } else {
            count.Add(key, 1);
          }
        }
      }
    }
    
    KeyValuePair<KeyValuePair<int, int>, int> most =
      count.ToList().OrderByDescending(n => n.Value).First();
    
    Console.WriteLine("{0}, {1} ({2})", most.Key.Key, most.Key.Value, most.Value);
