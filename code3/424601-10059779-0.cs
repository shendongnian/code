    Pass by value with ref:
    
        static void Main(string[] args)
            {
                StringBuilder y = new StringBuilder();
                y.Append("hello");
                Foo(ref y);
    Console.WriteLine(y);
           }
    
            private static void Foo(ref StringBuilder y)
            {
                StringBuilder sb = y;
                sb.Append("99");
            }
    
    o/p : hello99
    
    Pass by value without ref:
    
        static void Main(string[] args)
            {
                StringBuilder y = new StringBuilder();
                y.Append("hello");
                Foo(y);
    Console.WriteLine(y);
           }
    
            private static void Foo(StringBuilder y)
            {
                StringBuilder sb = new StringBuilder
                sb.Append("99");
            }
    o/p : hello
