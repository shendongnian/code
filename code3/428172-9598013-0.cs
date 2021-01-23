    public static class TestHandler
    {
        static TestHandler()
        {
            Tests = new Container();
            Tests.Configure(x => x.Scan(scanner =>
                {
                    scanner.AssembliesFromPath(@"TestCases");
                    scanner.AddAllTypesOf<ITest>().NameBy(i => i.Name);
                }));
        }
        public static IContainer Tests { get; set; }
    
        public static ITest GetHandler(string handlerName)
        {
            return Tests.GetNamedInstance<ITest>(handlerName);
        }
    }
