    class Program
    {
        class A
        {
            public static List<A> MyProperties = new List<A>();
            public int Id { get; set; }
            public string Value { get; set; }
        }
        static void Main(string[] args)
        {
            A a = new A() { Id = 1, Value = "Test" };
            A.MyProperties.Add(a);
            MyMethod(1);
        }
        static void MyMethod(int id)
        {
            var instance = A.MyProperties.First(link => link.Id == id);
            Console.WriteLine(instance.Value);
        }
    }
