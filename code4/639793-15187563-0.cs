    public class A
    {
        int aInt;
        public A()
        {
            aInt = 1;
            aInt = aInt.DoSomething();
            // aInt is now 6
        }
    }
    public static class Extension
    {
        public static int DoSomething (this int value)
        {
            return value += 5;
        }
    }
