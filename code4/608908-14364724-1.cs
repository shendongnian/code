    [Flags]
    public enum MyFlags : short
    {
        Foo = 0x1,
        Bar = 0x2,
        Baz = 0x4
    }
    public static class Program
    {
        public static void Main()
        {
            CheckFlags(MyFlags.Bar | MyFlags.Baz);
        }
        public static void CheckFlags(MyFlags flags)
        {
            if (flags.HasFlag(MyFlags.Foo))
                Console.WriteLine("Item has Foo flag set");
            if (flags.HasFlag(MyFlags.Bar))
                Console.WriteLine("Item has Bar flag set");
            if (flags.HasFlag(MyFlags.Baz))
                Console.WriteLine("Item has Baz flag set");
        }
    }
