    class Program
    {
        static void Main(string[] args)
        {
            var c = new Class1();
            c.Method1();
        }
    }
    class Class1
    {
        public void Method1()
        {
            var obj = new TestClass();
            obj.TestMethod1();
        }
    }
    class TestClass
    {
        public void TestMethod1()
        {
            TestMethod2();
            var mth = new StackTrace().GetFrame(1).GetMethod();
            var clss = mth.ReflectedType.Name;
            Console.WriteLine("Classname in Method1(): {0}", clss);
        }
        private void TestMethod2()
        {
            //get the calling class 
            var mth = new StackTrace().GetFrame(1).GetMethod();
            var clss = mth.ReflectedType.Name;
            Console.WriteLine("Class in .Method2(): {0}", clss);
        }
    }
