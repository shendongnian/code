    public class Foo : IDisposable
    {
        public void Dispose()
        {
            Console.WriteLine("I was disposed!");
        }
    }
    private static void Main(string[] args)
    {
        try
        {
            using (var foo = new Foo())
                throw new Exception("I'm mean");
        }
        catch { }
     }
