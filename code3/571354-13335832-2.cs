    static void Main(string[] args)
    {
        int numStrings = 2700000;
        List<string> strings = new List<string>(numStrings);
        // pre-jit the generic type
        new List<string>(new[] { "str1", "str2" }).Sort();
        using (var fs = File.Open("C:\\guids.txt", FileMode.Open))
        using (var r = new StreamReader(fs))
        {
            Console.WriteLine("Loading strings...");
            string str;
            while ((str = r.ReadLine()) != null)
            {
                strings.Add(str);
            }
        }
        Console.WriteLine("Beginning sort...");
        var sw = Stopwatch.StartNew();
        strings.Sort();
        sw.Stop();
        Console.WriteLine(sw.Elapsed.Seconds + " seconds, or " + sw.Elapsed.Milliseconds + " milliseconds");
    }
