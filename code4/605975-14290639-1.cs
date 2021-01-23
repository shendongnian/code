    [ServiceContract]
    public interface IProdsService
    {
    	[OperationContract]
    	void Alert(string msg);
    }
    
    /// <summary>
    /// Host Class
    /// </summary>
    public class ProdsService : IProdsService
    {
    	public ProdsService()
    	{
    		Console.WriteLine("Service instantiated.");
    	}
    
    	public void Alert(string msg)
    	{
    		Console.WriteLine(msg);
    	}
    }
    
    /// <summary>
    /// Client proxy wrapper
    /// </summary>
    public class ProdsServiceClient : ClientBase<IProdsService>, IProdsService
    {
    	public ProdsServiceClient()
    	{
    	}
    
    	public ProdsServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
    		base(binding, remoteAddress)
    	{
    	}
    
    	public void Alert(string msg)
    	{
    		base.Channel.Alert(msg);
    	}
    }
    
    class Program
    {
    	static ManualResetEvent _reset;
    
    	static void Main(string[] args)
    	{
    		string host = "localhost";
    		int port = 8888;
    
    		//ManualResetEvent is used for syncing start/stop of service.
    		_reset = new ManualResetEvent(false);
    
    		var action = new Action<string, int>(Start);
    		var result = action.BeginInvoke(host, port, null, null);
    			
    		//Wait for svc startup, this can be synced with resetEvents.
    		Thread.Sleep(2000);
    
    		//Create a client instance and send your messages to host
	        using (var client = new ProdsServiceClient(new NetTcpBinding(), new EndpointAddress(string.Format("net.tcp://{0}:{1}", host, port))))
		    {
			 client.Alert("Test message");
			 string msg = string.Empty;
			 do
			 {
				Console.Write("Type a message to send (X to exit): ");
				msg = Console.ReadLine();
				client.Alert(msg);
			 }
			 while (!msg.Trim().ToUpper().Equals("X"));
	        }
    		//Signal host to stop
    		_reset.Set();
    		action.EndInvoke(result);
    
    		Console.Write("Press any to exit.");
    		Console.ReadKey();
    	}
    
    	static void Start(string host, int port)
    	{
    		string uri = string.Format("net.tcp://{0}:{1}", host, port);
    		//var server = new ProdsService();
    		ServiceHost prodService = new ServiceHost(typeof(ProdsService));
    		prodService.AddServiceEndpoint(typeof(IProdsService), new NetTcpBinding(), uri);
    		Console.WriteLine("Service host opened");
    		prodService.Open();
    			
    		//Wait until signaled to stop
    		_reset.WaitOne();
    		Console.WriteLine("Stopping host, please wait...");
    		prodService.Close();
    		Console.WriteLine("Service host closed");
    	}
    }
    
