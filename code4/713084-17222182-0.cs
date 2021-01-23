    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            HostLib.Foo foo = new HostLib.Foo();
            foo.Bar();
        }
    }
