    public class Super
    {
        public class Sub
        {
            public static string OtherValue { get { return Super.SomeValue; } }
        }
        public static string SomeValue { get { return "Outer"; } }
    }
