    public class TestClass
    {
        public int FooMethod()
        {
            return 1;
        }
        public void FooMethod()
        {
            return;
        }
        public string FooMethod()
        {
            return "foo";
        }
    }
    
    static void Main()
    {
        TestClass test = new TestClass();
    
        Console.WriteLine(test.FooMethod()); // which FooMethod should be called here?
    }
