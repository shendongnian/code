    private static void Main(string[] args)
    {            
       Console.In.ReadToEnd().Split(new[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(ulong.Parse)
            .Reverse()
            .Select(n => Math.Sqrt(n).ToString("F4"))
            .ToList()
            .ForEach(Console.WriteLine);
    }
