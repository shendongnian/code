    class Program
    {
        static void Main(string[] args)
        {
            using (MyClass obj = new MyClass())
            {
                obj.SayHello();
            }
            // obj.SayHello(); // Error: The name 'obj' does not exist in the current context
        }
    }
    class MyClass : IDisposable
    {
        public void SayHello()
        {
            Console.WriteLine("Hello");
        }
        public void Dispose()
        {
            // Do something (e.g: close some open connection, etc)
        }
    }
