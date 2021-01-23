    public class Super
    {
        private static string SomeValue { get { return "Outer"; } }
        public class Sub
        {
            public static string OtherValue { get { return SomeValue; } }
        }
    }
