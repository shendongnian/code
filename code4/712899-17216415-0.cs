    public class MyClass
    {
        public string MethodA(int i)
        {
            return StaticMethodA(i);
        }
	
        private static string StaticMethodA(int i)
        {
            return "StaticMethodA called, i is " + i;
        }
        public static void MethodX()
        {
            string str = StaticMethodA(5);
        }
    }
