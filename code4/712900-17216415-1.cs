    public class MyClass
    {
        public string MethodA(int i)
        {
            return StaticMethodA(i);
        }
	
        private static string StaticMethodA(int i)
        {
            return String.Format("i is {0}", i);
        }
        public static void MethodX()
        {
            string str = StaticMethodA(5);
        }
    }
