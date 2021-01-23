    class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer()
                .Register(Component.For<IConnector>().ImplementedBy<ConnectorA>().Named("ConnectorA"))
                .Register(Component.For<IConnector>().ImplementedBy<ConnectorB>().Named("ConnectorB"));
            var connectorA = container.Resolve<IConnector>("ConnectorA");
            Console.WriteLine("Connector type: {0}", connectorA.GetType());
            var connectorB = container.Resolve<IConnector>("ConnectorB");
            Console.WriteLine("Connector type: {0}", connectorB.GetType());
            Console.ReadKey();
        }
    }
    public interface IConnector
    {
    }
    public class ConnectorA : IConnector
    {
         
    }
    public class ConnectorB : IConnector
    {
         
    }
