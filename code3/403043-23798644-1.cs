    class Program
    {
        static void Main(string[] args)
        {
            A a = new A(new A());
            a.Name = "Roger";
            a.a.Name = "John";
            Console.WriteLine("{0}, {1}", a.Name, a.a.Name);
        }
    }
