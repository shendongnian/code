    Console.Write("enter number: ");
    int num = Int32.Parse(Console.ReadLine());
        
    Enumerable.Range(1, num)
              .Concat(Enumerable.Range(1, num - 1).Reverse())
              .Select(x => String.Join("", Enumerable.Repeat(x.ToString(),x)))
              .ToList()
              .ForEach(line => Console.WriteLine(line));
