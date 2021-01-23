    static void Main(string[] args)
    {
        string[] source = new string[1000000];
        for (int i = 0; i < source.Length; i++)
        {
            source[i] = "string " + i.ToString();
        }
        string[] buffer;
        Console.WriteLine("Starting stop watch");
        Stopwatch sw = new Stopwatch();
        for (int n = 0; n < 5; n++)
        {
            sw.Reset();
            sw.Start();
            for (int i = 0; i < source.Length; i += 100)
            {
                buffer = new string[100];
                Array.Copy(source, i, buffer, 0, 100);
            }
            sw.Stop();
            Console.WriteLine("Array.Copy: " + sw.ElapsedMilliseconds.ToString());
            sw.Reset();
            sw.Start();
            for (int i = 0; i < source.Length; i += 100)
            {
                buffer = new string[100];
                buffer = source.Skip(i).Take(100).ToArray();
            }
            sw.Stop();
            Console.WriteLine("Skip/Take: " + sw.ElapsedMilliseconds.ToString());
            sw.Reset();
            sw.Start();
            String[][] chunks = source                            
                .Select((s, i) => new { Value = s, Index = i })                            
                .GroupBy(x => x.Index / 100)                            
                .Select(grp => grp.Select(x => x.Value).ToArray())                            
                .ToArray();
            sw.Stop();
            Console.WriteLine("LINQ: " + sw.ElapsedMilliseconds.ToString());
        }
        Console.ReadLine();
    }
