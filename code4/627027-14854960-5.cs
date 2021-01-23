    public class Class1
    {
        private Class1() { }
        public static void Method() { }
        private string member; // valid, but pointless
    }
    public static class Class2
    {
        public static void Method() { }
        private string member; // error CS0708
    }
