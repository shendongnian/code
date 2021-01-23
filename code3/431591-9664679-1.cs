    static void Main(string[] args)
    {
        IEnumerable<String> Hotels = new List<String>{"sdsfsdf"};
        String Hotel;
        Console.WriteLine("RES " + Hotels.Count());
        if (Hotels.Count() > 0)
        {
            Hotel = Hotels.First();
        }
        Console.WriteLine("RES " + Hotels.Count());
        Console.WriteLine("RES " + Hotels.Count());
    }
