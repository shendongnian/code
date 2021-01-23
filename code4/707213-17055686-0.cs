    private static void Main(string[] args)
    {            
        var input = Console.In.ReadToEnd();
        var longs = input.Split(new[] {' ', '\r', '\n'}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(ulong.Parse)                     
                    .Reverse()
                    .ToList();                  
    
        foreach (var p in longs.Select(n => Math.Sqrt(n)))
        {                
            Console.WriteLine("{0:F4}", p);
        }                   
    }
