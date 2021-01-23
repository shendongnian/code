    public class Constants
    {
        public readonly int MIN;
        public Constants() { MIN = 18; }
    }
    public class Foo
    {
        public static Constants GlobalConstants { get; private set; }
        public static void Main()
        {
            // do lots of stuff
            GlobalConstants = new GlobalConstants();
        }
    }
