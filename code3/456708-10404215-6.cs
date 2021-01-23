    internal class Class1 : IDisposable
    {
        public Class1()
        {
            Console.WriteLine("Construct");
        }
        public void Dispose()
        {
            Console.WriteLine("Dispose");
        }
        ~Class1()
        {
            Console.WriteLine("Destruct");
        }
    }
