    Console.WriteLine("Enter the height: ");
    int h = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter the width: ");
    string w = Convert.ToInt32(Console.ReadLine());
    
    int[,] arr = new int[h, w];
    
    for (int i = 0; i < h; ++i)
      for (int j = 0; j < w; ++j)
        arr[i, j] = Convert.ToInt32(Console.ReadLine());
