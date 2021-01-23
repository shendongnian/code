    public class MyClass
    {
        private static int instances = 0;
        public MyClass()
        {
            instances++;
        }
        ~MyClass()
        {
            instances--;
        }
        public static int GetActiveInstances()
        {
            return instances;
        }
    }
