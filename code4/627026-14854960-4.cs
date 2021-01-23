    public class Class1
    {
        private Class1() { }
        private static Class1 instance = new Class1();
        public static Class1 Instance
        {
            get { return instance; }
        }
    }
