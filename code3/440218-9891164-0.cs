    class Test
    {
        public delegate void MyFooSig();
        public MyFooSig Foo { get; set; }
    }
    class Test1
    {
        public Action Foo { get; set; }
        public Func<string, int, Test> MyOtherFoo { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var test = new Test
            {
                Foo = () => Console.Write("I'm in Foo"),
            };
            test.Foo();
            var test1 = new Test1
            {
                Foo = () => Console.WriteLine("Foo via Action delegates"),
                MyOtherFoo = (s, i) => new Test 
                { 
                    Foo = () => Console.WriteLine("here it's me again..."),
                },
            };
            test1.Foo();
            test1.MyOtherFoo("", 1).Foo();
        }
    }
