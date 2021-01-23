    static void Main(string[] args)
    {
        List<string> Months = new List<string>() { "Jan", "Feb", "Mar", "Apr", "May", "June" };
        Random r = new Random();
        Parallel.ForEach(Months, (x) => ProcessRandom(x, r));
        Console.ReadLine();
    }
    public static void ProcessRandom(string s, Random r)
    {
        int i = r.Next(1, 100);
        Thread.Sleep(1000);
        Console.WriteLine(string.Format("Month Name {0} and Random ID assigned {1}", s, i));
    }
