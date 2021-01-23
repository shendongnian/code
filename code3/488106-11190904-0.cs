    class FormattersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<IFormatter>()
                    .ImplementedBy<XmlFormatter>()
                    .Named(Format.Xml.ToString()));
            container.Register(
                Component
                    .For<IFormatter>()
                    .ImplementedBy<JsonFormatter>()
                    .Named(Format.Json.ToString()));
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer();
            container.Install(new FormattersInstaller());
            var xmlFormatter = container.Resolve<IFormatter>(Format.Xml.ToString());
            var jsonFormatter = container.Resolve<IFormatter>(Format.Json.ToString());
            // use the formatters...
        }
    }
