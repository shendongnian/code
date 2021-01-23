    Console.Write("enter number: ");
    int num = Int32.Parse(Console.ReadLine());
        
    Enumerable.Range(1, num)
              .Concat(Enumerable.Range(1, num - 1).Reverse())
              .Select(x => new String(x.ToString()[0], x))
              .ToList()
              .ForEach(line => Console.WriteLine(line));
