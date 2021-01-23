            public class CustomHeaderMessageInspector : IDispatchMessageInspector
            {
                Dictionary<string, string> requiredHeaders;
                public CustomHeaderMessageInspector (Dictionary<string, string> headers)
                {
                    requiredHeaders = headers ?? new Dictionary<string, string>();
                }
                public object AfterReceiveRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel, System.ServiceModel.InstanceContext instanceContext)
                {
                    return null;
                }
                public void BeforeSendReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
                {
                    var httpHeader = reply.Properties["httpResponse"] as HttpResponseMessageProperty;
                    foreach (var item in requiredHeaders)
                    {
                        httpHeader.Headers.Add(item.Key, item.Value);
                    }           
                }
            }
    
            public class EnableCrossOriginResourceSharingBehavior : BehaviorExtensionElement, IEndpointBehavior
            {
                public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
                {
           
                }
                public void ApplyClientBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
                {
            
                }
                public void ApplyDispatchBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher)
                {
                    var requiredHeaders = new Dictionary<string, string>();
                    requiredHeaders.Add("Access-Control-Allow-Origin", "*");
                    requiredHeaders.Add("Access-Control-Request-Method", "POST,GET,PUT,DELETE,OPTIONS");
                    requiredHeaders.Add("Access-Control-Allow-Headers", "X-Requested-With,Content-Type");
                    endpointDispatcher.DispatchRuntime.MessageInspectors.Add(new CustomHeaderMessageInspector(requiredHeaders));
                }
                public void Validate(ServiceEndpoint endpoint)
                {
            
                }
                public override Type BehaviorType
                {
                    get { return typeof(EnableCrossOriginResourceSharingBehavior); }
                }
                protected override object CreateBehavior()
                {
                    return new EnableCrossOriginResourceSharingBehavior();
                }
            }
        <extensions>
         <behaviorExtensions>        
                    <add name="crossOriginResourceSharingBehavior" type="Services.Behaviours.EnableCrossOriginResourceSharingBehavior, Services, Version=1.0.0.0, Culture=neutral" />        
          </behaviorExtensions>      
        </extensions>
        
        <endpointBehaviors>      
         <behavior name="jsonBehavior">
          <webHttp />
           <crossOriginResourceSharingBehavior />
         </behavior>
        </endpointBehaviors>
        <endpoint address="api" binding="webHttpBinding" behaviorConfiguration="jsonBehavior" contract="Service.IServiceContract" />
            
