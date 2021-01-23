    int[] arr = new int[] { 2,3,4,5,6 };
    int[] slice = arr.Skip(2).Take(2).ToArray();
    // Multidimensional slice 
    int[,] parts = new int[2,3];
    int[] slice = arr.Cast<int>().Skip(2).Take(2).ToArray();
