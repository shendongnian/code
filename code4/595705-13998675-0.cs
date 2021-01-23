    class Program
    {
        delegate void D1();
        static void Main(string[] args)
        {
            var testObj = new Program();
            D1 myDelegate = testObj.TestMethod;
            myDelegate.Invoke();
        }
        void TestMethod()
        {
            Console.WriteLine("Foo!");
        }
    }
