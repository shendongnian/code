    public static int[] Subtract(int[] array, int value) {
      if (Object.ReferenceEquals(null, array))
        throw new ArgumentNullException("array");
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
    // Addition. Be careful: addition can't be reversed subtraction,  
    // since subtraction isn't unequivocal:
    // [1, 2, 3] - 5 = [1]
    // [1, 5] - 5 = [1]
    // [1, 1, 1, 1, 2] - 5 = [1]
    // [6] - 5 = [1]
    // So for [1] + 5 can return many answers. In this code I opted
    // [1] + 5 = [6] (the last test case)
    public static int[] Addition(int[] array, int value) {
      return Subtraction(array, -value);
    }
    ....  
    
    int[] test1 = Subtract(new int[] { 1, 2, 3, 4, 5 }, 1); // <- [1, 2, 3, 4, 4] 
    int[] test2 = Subtract(new int[] { 1, 2, 3, 4, 5 }, 5); // <- [1, 2, 3, 4] 
    int[] test3 = Subtract(new int[] { 1, 2, 3, 4, 5 }, 6); // <- [1, 2, 3, 3] 
    int[] test4 = Subtract(new int[] { 1, 2, 3, 4, 5 }, 10); // <- [1, 2, 2]
    int[] test5 = Subtract(new int[] { 1, 2, 3, 4, 5 }, 1000); // <- [] 
    int[] test6 = Subtract(new int[] { 1, 2, 3, 4, 5 }, -1); // <- [1, 2, 3, 4, 6]
    int[] test7 = Subtract(new int[] { 2, 2 }, 2); // <- [2]
