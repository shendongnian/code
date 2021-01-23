    public static void Go() {
        Console.WriteLine("Start fosterage...\n");
        var t1 = Sleep(5000, "Kevin");
        var t2 = Sleep(3000, "Jerry");
        var result = Task.WhenAll(t1, t2).Result;
        Console.WriteLine("\nMy precious spare time last for only {0}ms", result.Max());
        Console.WriteLine("Press any key and take same beer...");
        Console.ReadKey();
    }
    private static async Task<int> Sleep(int ms, string n) {
            Console.WriteLine("{0} going to sleep for {1}ms :)", n, ms);
            await Task.Delay(ms);
            Console.WriteLine("{0} waked up after {1}ms :(", n, ms);
            return ms;
    }
