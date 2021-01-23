    enum SqlDbType
    {
        Zero = 0,
        One = 1
    }
    class TestClass
    {
        public TestClass(string s, object o)
        { System.Console.WriteLine("{0} => TestClass(object)", s); } 
        public TestClass(string s, SqlDbType e)
        { System.Console.WriteLine("{0} => TestClass(Enum SqlDbType)", s); }
    }
    // This is perfectly valid:
    SqlDbType valid = 0;
    // Whilst this is not:
    SqlDbType ohNoYouDont = 1;
    var a1 = new TestClass("0", 0);
    // 0 => TestClass(Enum SqlDbType)
    var a2 = new TestClass("1", 1); 
    // => 1 => TestClass(object)
