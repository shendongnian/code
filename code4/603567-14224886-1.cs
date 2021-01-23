    enum E
    {
        Zero = 0,
        One = 1
    }
    class A
    {
        public A(string s, object o)
        { System.Console.WriteLine("{0} => A(object)", s); } 
        public A(string s, E e)
        { System.Console.WriteLine("{0} => A(Enum E)", s); }
    }
    // This is perfectly valid:
    E e1 = 0;
    
    A a1 = new A("0", 0);
    // 0 => A(Enum E)
    A a2 = new A("1", 1); 
    // => 1 => A(object)
