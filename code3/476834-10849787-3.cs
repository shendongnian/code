    class something : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("Disposing");
            Console.WriteLine(Environment.StackTrace);
        }
    }
    static IEnumerable<string> ie()
    {
        using (new something())
        {
            Console.WriteLine("first");
            yield return "first";
            Console.WriteLine("second");
            yield return "second";
        }
    }
    static void Main(string[] args)
    {
        Console.WriteLine("before");
        ie().First();
        Console.WriteLine("after");
    }
