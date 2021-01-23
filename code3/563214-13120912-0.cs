    public class IntWrapper
    {
        public IntWrapper( int val = 0 ) { Value = val; }
        public int Value { get; set; }
    }
    
    static void Main(string[] args)
    {
        IntWrapper a = new IntWrapper(5);
        TestClass testObj = new TestClass(a);
        testObj.Work();
    }
    public class TestClass
    {
        IntWrapper _a;
        public TestClass(IntWrapper a)
        {
            _a = a;
        }
    
        public void Work()
        {
            Console.WriteLine("Work before changing: a=" + _a.Value);
            _a.Value = 0;
            Console.WriteLine("Work after changing: a=" + _a.Value);
        }
    }
