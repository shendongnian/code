       using System.ServiceModel; 
    using System.ServiceModel.Channels; 
     OperationContext context = OperationContext.Current; 
    MessageProperties prop = context.IncomingMessageProperties; 
    RemoteEndpointMessageProperty endpoint =    
     prop[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
     string ip = endpoint.Address; 
