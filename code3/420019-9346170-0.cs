    static void Main(string[] args)
    {
      var sw = new Stopwatch();
      sw.Start();
      for (short i = 0; i < short.MaxValue; i++)
      {
        var foo = IsValid1(i);
      }
      sw.Stop();
      var result1 = sw.Elapsed;
      Console.WriteLine(result1);
    
      sw.Start();
      for (short i = 0; i < short.MaxValue; i++)
      {
        var foo = IsValid2(i);
      }
      sw.Stop();
      var result2 = sw.Elapsed;
      Console.WriteLine(result2);
      Console.ReadKey();
    }
    static bool IsValid1(object value)
    {
      var convertible = value as IConvertible;
      if (convertible != null)
        return convertible.ToInt64(null) != 0;
      return true;
    }
    static bool IsValid2(object value)
    {
      if (value != null)
      {
        long amount;
        if (long.TryParse(value.ToString(), out amount))
          return amount != 0;
      }
      return true;
    }
