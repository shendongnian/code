    public static void Main() {
        bool a = bool.Parse("false");
        bool b = bool.Parse("true");
        bool c = bool.Parse("true");
        var sw = new Stopwatch();
        const int Max = 1000000000;
        int count = 0;
        sw.Start();
        // The loop will increment count Max times; let's measure how long it takes
        for (int i = 0; i != Max; i++) {
            count++;
        }
        sw.Stop();
        var baseTime = sw.ElapsedMilliseconds;
        sw.Start();
        count = 0;
        for (int i = 0; i != Max; i++) {
            if (a.Equals(c)) count++;
            if (b.Equals(c)) count++;
        }
        sw.Stop();
        Console.WriteLine(sw.ElapsedMilliseconds - baseTime);
        sw.Reset();
        count = 0;
        sw.Start();
        for (int i = 0; i != Max; i++) {
            if (a==c) count++;
            if (b==c) count++;
        }
        sw.Stop();
        Console.WriteLine(sw.ElapsedMilliseconds - baseTime);
        sw.Reset();
        count = 0;
        sw.Start();
        for (int i = 0; i != Max; i++) {
            if (!a) count++;
            if (!b) count++;
        }
        sw.Stop();
        Console.WriteLine(sw.ElapsedMilliseconds - baseTime);
    }
