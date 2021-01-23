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
            Console.WriteLine((classA.MyProperty == null)
                ? "Not initialized" : "Initialized");
            classA.MyProperty = (a) =>
            {
                if (a == "1")
                    return new ClassB1();
                else if (a == "2")
                    return new ClassB2();
                else
                    return null;
            };
            Console.WriteLine((classA.MyProperty == null)
                ? "Not initialized" : "Initialized");
            object
                c1 = classA.MyProperty.Invoke("1"),
                c2 = classA.MyProperty.Invoke("2"),
                c3 = classA.MyProperty.Invoke("3");
            Console.WriteLine((c1 != null) ? c1.GetType().Name : "null");
            Console.WriteLine((c2 != null) ? c2.GetType().Name : "null");
            Console.WriteLine((c3 != null) ? c3.GetType().Name : "null");
        }
    }
