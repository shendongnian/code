    public class Test2
    {
        public static Action<int> TestDelegate { get; set; }
        public static void PrintInt(int x)
        {
            Debug.WriteLine("int {0}", x);
        }
        public static void TestGetMethodName()
        {
            TestDelegate = PrintInt;
            Debug.WriteLine("TestDelegate method name is {0}", TestDelegate.GetMethodInfo().Name);
        }
    }
