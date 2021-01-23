    for (int i = 1; i <= 100; i++)
    {
      var x = combinations.Where(n => i % n.Item1 == 0);
    	
      if (x.Count() == 0)
        Console.Write(i);
      else
        Console.Write(string.Join("",x.Select(e => e.Item2)));
    
      Console.Write(Environment.NewLine);
    }
