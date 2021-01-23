    class Test
    {
        static void Main()
        {
            Foo(true, false, true);
        }
        
        static void Foo(bool x, bool y, bool z)
        {
            A = x || (y && z);
            B = x || (y && z);
        }
        
        static bool A { get; set; }
        static bool B { get; set; }
    }
