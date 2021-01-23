    [ComVisible(true)]
    [Guid("0818F830-DA37-4167-BF31-3A2C55A9BF2B")]        
    public class DataSystemModule : IDataSystemInterface
    {
    	private Dispatcher m_dispatcherListener = null;
    	private IDataSystemInterfaceEventListener m_listener = null;
    	public IDataSystemInterfaceEventListener Listener
    	{
    		get
    		{
    			return m_listener;
    		}
    		set
    		{
    			m_dispatcherListener = Dispatcher.CurrentDispatcher;
    			m_listener = value;
    		}
    	} 
    }
