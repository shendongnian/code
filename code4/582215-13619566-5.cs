    static void Main(string[] args) {
        const int N = 1000000;
        const int M = 10;
        Stopwatch s;
        // Generate test list of strings.
        var list = Enumerable.Range(0, N).Select(n => n.ToString());
    
        // Just so it's enumerated once before.
        var ar = list.ToArray(); 
    
        // Try Jonathon's method M times.
        s = Stopwatch.StartNew();
        for (int x = 0; x < M; x++) {
            int i = 0;
            //var dict1 = list.ToDictionary(_ => i++);    // Before question edit
            var dict1 = list.ToDictionary(x => x, _ => i++);
        }
        s.Stop();
        Console.WriteLine("Jonathon's i++ method took {0} ms", s.ElapsedMilliseconds);
    
        // Try pst's method M times.
        s = Stopwatch.StartNew();
        for (int x = 0; x < M; x++) {
            var dict2 = list.Select((v, j) => new {v, j}).ToDictionary(p => p.v, p => p.j);
        }
        s.Stop();
        Console.WriteLine("psts' Select() method took {0} ms", s.ElapsedMilliseconds);
    
        Console.ReadLine();
    }
