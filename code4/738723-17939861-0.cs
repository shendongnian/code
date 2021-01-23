    static void Main(string[] args)
    {
        IPAddress a, b;
        a = new IPAddress(new byte[] { 10, 100, 12, 21 });
        b = new IPAddress(new byte[] { 10, 100, 12, 21 });
        Console.WriteLine("Value is {0}", a.Equals(b));
        Console.ReadLine();
    }
