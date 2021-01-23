    class Program
    {
        class SomeClass
        {
            public string Content { get; set; }
        }
        static void Main(string[] args)
        {
            SomeClass a, b;
            a = new SomeClass { Content = "" };
            b = new SomeClass { Content = "" };
            ArrayList al = new ArrayList();
            al.Add(a);
            al.Add(b);
            SomeFunction(al);
            Console.WriteLine(a.Content);
            Console.WriteLine(b.Content);
            Console.ReadLine();
        }
        public static void SomeFunction(ArrayList param)
        {
            ((SomeClass)param[0]).Content = "aa";
            ((SomeClass)param[1]).Content = "bb";
        }
    }
