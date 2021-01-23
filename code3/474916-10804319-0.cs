      Console.WriteLine();
      for (int i = 0; i <= 100; i++)
      {
        System.Threading.Thread.Sleep(10);
        Console.Write("\x000DProgress: " + i);
      }
