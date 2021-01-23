    class A
            {
                public string a;
                public string b;
                public A(string x, string y)
                {
                    a = x;
                    b = y;
                }
            }
            static void Main(string[] args)
            {
                A[] tab = { new A("1", "1"), new A("2", "0"), new A("3", "1"), new A("4", "0"), new A("5", "1") };
                var g = tab.GroupBy(x => x.b);
                foreach (var x in g)
                {
                    
                    foreach (var y in x)
                    {
                        Console.WriteLine(y.a + "/" + y.b);
                    }
                    Console.WriteLine("----");
                }
                Console.ReadKey();
    
            }
