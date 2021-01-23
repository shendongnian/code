    /// <summary>
    /// Extension element for logging information about request.
    /// </summary>
    public class LogBehaviorExtensionElement : BehaviorExtensionElement
    {
    	protected override object CreateBehavior()
        {
    		return new LogEndpointBehavior();
        }
    
        public override Type BehaviorType
        {
    		get
            {
                return typeof(LogEndpointBehavior);
            }
        }
    }
    
    /// <summary>
    /// Custom log endpoint behaviour.
    /// </summary>
    public class LogEndpointBehavior : IEndpointBehavior
    {
    	public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        { }
    
        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        { }
    
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
    		var inspector = new DispatchMessageInspector();
            endpointDispatcher.DispatchRuntime.MessageInspectors.Add(inspector);
        }
    
        public void Validate(ServiceEndpoint endpoint)
        { }
    }
    
