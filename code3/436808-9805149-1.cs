    class Program
    {
        public delegate void Del(string message);
    
        public void DelegateMethod(string message)
        {
            System.Console.WriteLine(message);
        }
    
        static void Main()
        {
            Del handler = new Del(new Program().DelegateMethod);
            handler("Hello World");
            Console.Read();
        }
    }
