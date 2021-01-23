    class Program
    {
        static void Main(string[] args)
        {
            Container container = new Container();
            BootStrapper.Configure(container);
            container.Verify();
            using (container.BeginLifetimeScope())
            {
                MainActivity entryPoint = container.GetInstance<MainActivity>();
                entryPoint.test();
            }
        }
    }
