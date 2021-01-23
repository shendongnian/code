    class something : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("disposing");
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
        ie().First();
    }
