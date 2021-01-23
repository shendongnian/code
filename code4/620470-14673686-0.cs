    public enum Scopes
    {
        TestScope
    }
    public class Test
    {
       public string Description { get; set; }
    }
     
    public class Tester
    {
        public void DoTest()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<Test>()
                .OnActivating(args => args.Instance.Description = "FromRoot")
                .SingleInstance();
            var container = builder.Build();
            var scope = container.BeginLifetimeScope(Scopes.TestScope, b => b
                .RegisterType<Test>()
                .InstancePerMatchingLifetimeScope(Scopes.TestScope)
                .OnActivating(args => args.Instance.Description = "FromScope"));
            var test1 = container.Resolve<Test>();
            Console.WriteLine(test1.Description); //writes FromRoot
            var test2 = scope.Resolve<Test>();
            Console.WriteLine(test2.Description); //writes FromScope
            Console.ReadLine();
        }
    }
