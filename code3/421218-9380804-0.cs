      int[] arr = new int[]{1, 2, 3, 4, 5, 6, 7};
      int t = arr[3];
      int a = 0;
      var start = DateTime.UtcNow;
      for (int i = 0; i < 1000000000; i++)
      {
        a += t;
      }
      Console.WriteLine(a);
      Console.WriteLine(DateTime.UtcNow-start);
      a = 0;
      start = DateTime.UtcNow;
      for (int i = 0; i < 1000000000; i++)
      {
        a += arr[3];
      }
      Console.WriteLine(a);
      Console.WriteLine(DateTime.UtcNow - start);
