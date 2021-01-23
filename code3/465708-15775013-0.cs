    public class MyHubActivator : IHubActivator
    {
    	private readonly Container _container;
    
    	public UnityHubActivator(Container container)
    	{
    		_container = container;
    	}
    
    	#region Implementation of IHubActivator
    
    	public IHub Create(HubDescriptor descriptor)
    	{
    		return _container.GetInstance(descriptor.HubType) as IHub;
    	}
    
    	#endregion
    }
