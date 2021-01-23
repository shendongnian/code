    static void Main(string[] args)
    {
      long max = 6;
      for (long i = 0; i <= 2 * max + 1; i++)
      {
        Console.Write("{0} ", i.Ziggurat(max));
      }
    }
