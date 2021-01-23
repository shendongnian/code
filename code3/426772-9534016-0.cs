    public enum FooBar
    {
        Foo = 0,
        Bar
    }
    internal class Program
    {
        private static FooBar fb = FooBar.Bar;
        private static void Main()
        {
            new Thread(() =>
                           {
                               while (true)
                               {
                                   if (Program.fb == FooBar.Foo) // or try default(FooBar), which is the same
                                   {
                                       throw new Exception("Not threadsafe");
                                   }
                               }
                           }).Start();
            while (true)
            {
                if (!Enum.TryParse("Bar", true, out fb) || fb == FooBar.Foo)
                {
                    throw new Exception("Parse error");
                }
            }
        }
    }
