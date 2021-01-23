    public class Super
    {
        public static string SomeValue { get { return "Outer"; } }
    }
    public class Sub
    {
        public static string OtherValue { get { return Super.SomeValue; } }
    }
