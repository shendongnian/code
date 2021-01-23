    public interface ISomeService : System.ServiceModel.IServiceChannel
    {
        ...
    }
    
    public class SomeServiceClient : System.ServiceModel.ClientBase<ISomeService>
    {
    }
