    public static int[] Subtract(int[] array, int value) {
      if (Object.ReferenceEquals(null, array))
        throw new ArgumentNullException("array");
      if (value < 0) 
        return Addition(array, -value);
      int s = 0;
      int index = 0;
      int delta = 0;
      for (int i = array.GetLength(0) - 1; i >= 0; --i) {
        s += array[i];
        if (s > value) {
          index = i;
          delta = s - value;
          break;
        }
      }
      // Too big a value is subtracted, let's return an empty array
      if ((index <= 0) && (delta <= 0)) // <- (delta <= 0) to prevent [x, ... z, 0] answers
        return new int[0];
      int[] result = new int[index + 1];
      for (int i = 0; i < index; ++i)
        result[i] = array[i];
      result[index] = delta;
      return result;
    }
    // Maximum possible electrons within orbital; 0 - s1, 1 - s1, 2 - p1, 3 - s2 etc.
    // Double arithmetic progression's here (main quantum number - level, orbital quantum number - s, p, d...)
    private static int MaxElectronsCount(int value) {
      Double n = (-1 + Math.Sqrt(1 + 8.0 * (value + 1))) / 2;
      int group = (int)(n + 1.0 - 1.0e-8); // <- round up to high limit
      int shift = group - (group * (group + 1) / 2 - value);
      return 2 + shift * 4;
    }
    // Electrons addition 
    public static int[] Addition(int[] array, int value) {
      if (Object.ReferenceEquals(null, array))
        throw new ArgumentNullException("array");
      if (value < 0)
        return Subtraction(array, -value);
      List<int> result = new List<int>();
      for (int i = 0; i < array.GetLength(0); ++i)
        result.Add(array[i]);
      int level = 0;
      while (value > 0) {
        if (result.Count <= level)
          result.Add(0);
        int max = MaxElectronsCount(level);
        int delta = max - result[level];
        if (delta > value)
          delta = value;
        if (delta > 0) {
          result[level] = result[level] + delta;
          value -= delta;
        }
        level += 1;
      }
      return result.ToArray();
    }
    ....  
    
    int[] test1 = Subtract(new int[] { 1, 2, 3, 4, 5 }, 1); // <- [1, 2, 3, 4, 4] 
    int[] test2 = Subtract(new int[] { 1, 2, 3, 4, 5 }, 5); // <- [1, 2, 3, 4] 
    int[] test3 = Subtract(new int[] { 1, 2, 3, 4, 5 }, 6); // <- [1, 2, 3, 3] 
    int[] test4 = Subtract(new int[] { 1, 2, 3, 4, 5 }, 10); // <- [1, 2, 2]
    int[] test5 = Subtract(new int[] { 1, 2, 3, 4, 5 }, 1000); // <- [] 
    int[] test6 = Subtract(new int[] { 1, 2, 3, 4, 5 }, -1); // <- [2, 2, 3, 4, 5]
    int[] test7 = Subtract(new int[] { 2, 2 }, 2); // <- [2]
    int[] test8 = Addition(new int[] {2, 1}, 16); // <- [2, 2, 6, 2, 6, 1]
