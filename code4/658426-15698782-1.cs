    Console.WriteLine("Enter the height: ");
    int h = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter the width: ");
    string w = Convert.ToInt32(Console.ReadLine());
    
    int[,] arr = new int[w, h];
    
    for (int i = 0; i < w; ++i)
      for (int j = 0; j <h; ++j)
        arr[i, j] = Convert.ToInt32(Console.ReadLine());
