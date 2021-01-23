    class Program
    {
        class C
        {
            public string Content { get; set; }
        }
        static void Main(string[] args)
        {
            C a, b;
            a = new C { Content = "" };
            b = new C { Content = "" };
            ArrayList al = new ArrayList();
            al.Add(a);
            al.Add(b);
            func(al);
            Console.WriteLine(a.Content);
            Console.WriteLine(b.Content);
            Console.ReadLine();
        }
        public static void func(ArrayList p)
        {
            ((C)p[0]).Content = "aa";
            ((C)p[1]).Content = "bb";
        }
    }
