    [ServiceContract]
    public interface IMyService
    {
        [OperationContract]
        string GetAddressAsString();
    }
    
    public class MyService : IMyService
    {
        public string GetAddressAsString()
        {
            RemoteEndpointMessageProperty clientEndpoint =
                OperationContext.Current.IncomingMessageProperties[
                RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
    
            return String.Format(
                "{0}:{1}",
                clientEndpoint.Address, clientEndpoint.Port);
        }
    }
