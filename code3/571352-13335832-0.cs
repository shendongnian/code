    static void Main(string[] args)
    {
        int numStrings = 2700000;
        List<string> strings = new List<string>(numStrings);
        using (var fs = File.Open("C:\\guids.txt", FileMode.Open))
        using (var r = new StreamReader(fs))
        {
            Console.WriteLine("Loadings strings...");
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
