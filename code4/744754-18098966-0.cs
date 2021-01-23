    class Program
    {
        interface IClassB { }
        class ClassB1 : IClassB { }
        class ClassB2 : IClassB { }
        class ClassA
        {
            public Func<string, IClassB> 
                MyProperty { get; set; }
        }
        static void Main(string[] args)
        {
            var classA = new ClassA();
            Console.WriteLine((classA.MyProperty != null) 
                ? "Not initialized" : "Initialized");
            classA.MyProperty = (a) =>
            {
                if (a == "1")
                    return new ClassB1();
                else
                    return new ClassB2();
            };
            Console.WriteLine((classA.MyProperty != null) 
                ? "Not initialized" : "Initialized");
            Console.WriteLine(classA.MyProperty
                .Invoke("1").GetType());
            Console.WriteLine(classA.MyProperty
                .Invoke("2").GetType());
        }
    }
