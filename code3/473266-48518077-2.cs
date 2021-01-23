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
