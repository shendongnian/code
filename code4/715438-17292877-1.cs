    ...
    this.serviceHost = new ServiceHost(typeof(HelloWorldWcfServiceMessage));
    this.serviceHost.Open();
    ...
    public class HelloWorldWcfServiceMessage : IHelloWorldWcfServiceMessage
    {
    }
    [ServiceContract(Namespace = "http://HelloWorldServiceNamespace", Name = "PublicHelloWorldWCFService")]
    public interface IHelloWorldWcfServiceMessage
    {
        [OperationContract]
        string HelloWorldMessage(string name);
    }
