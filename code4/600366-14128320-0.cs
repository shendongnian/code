    Enumerable.Range(0,Int32.MaxValue)
     .Select(_ => Int32.Parse(Console.ReadLine()))
     .TakeWhile(i => i != 0)
     .Select(i => {
        Console.WriteLine(String.Join("", Enumerable.Repeat("|", i)));
        return 0;})
 
