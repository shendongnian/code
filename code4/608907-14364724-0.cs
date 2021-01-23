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
            MyFlags fooBar = MyFlags.Foo | MyFlags.Bar;
    
            if (fooBar.HasFlag(MyFlags.Foo))
                Console.WriteLine("Item has Foo flag set");
            DoSomething(MyFlags.Bar | MyFlags.Baz);
        }
        public static void DoSomething(MyFlags flags)
        {
            if (flags.HasFlag(MyFlags.Foo))
                DoFoo();
            if (flags.HasFlag(MyFlags.Bar))
                DoBar();
            if (flags.HasFlag(MyFlags.Baz))
                DoBaz();
        }
    }
