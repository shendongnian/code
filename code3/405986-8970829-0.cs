	public class MyView : UserControl
	{   
		public MyView()
		{
			// Hardly best practice, but it'll work
			try
			{
				InitializeComponent();
			}
			catch(Exception caught)
			{
				EventAggregatorService.Instance.GetEvent<XamlExceptionEvent>().Publish(/* ... */);
			}
		}
	}
	public class EventAggregatorService
	{
		public IEventAggregator Instance { get { return _instance; } } 
		
		// NOTE: Must be called once in your bootstrapper to set the EA instance
		public static void SetEventAggregator(IEventAggregator instance)
		{
			_instance = instance;
		}
	}
