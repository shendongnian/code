    public class Foo
    {
        public static int MIN { get; private set; } }
        public static void Main()
        {
            MIN = 18;
            MIN = 23; // this will still work :(
        }
    }
