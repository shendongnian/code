    public void UsingModularArithmetic()
    { 
      string[] tokens_n = Console.ReadLine().Split(' ');
      int n = Convert.ToInt32(tokens_n[0]);
      int k = Convert.ToInt32(tokens_n[1]);
      int[] a = new int[n];
      for(int i = 0; i < n; i++)
      {
        int newLocation = (i + (n - k)) % n;
        a[newLocation] = Convert.ToInt32(Console.ReadLine());
      }
      foreach (int i in a)
        Console.Write("{0} ", i);
    }
