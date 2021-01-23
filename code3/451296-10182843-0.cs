    public IEnumerable<int> Twist(int min, int max)  {
      Random random = new Random();
      int result = 0;
      while (true) {
        result += random.Next(min, max);  // overflow pretty likely for large max
        System.Diagnostics.Debug.WriteLine(result);
        yield return result;
      }
    }
    
    // For a single element
    int oneResult = Twist(1, 5).First();
    
    // For the fifth
    int fifth = Twist(1, 5).Skip(4).First();
