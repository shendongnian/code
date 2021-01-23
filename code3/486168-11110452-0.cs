    [TestFixture]
    public class When_using_a_subset_of_a_WCF_interface
    {
    	[Test]
    	public void Should_call_interesting_method()
    	{
    		var serviceHost = new ServiceHost(typeof(Service));
    
    		serviceHost.AddServiceEndpoint( typeof(IServiceInterface), new BasicHttpBinding(), "http://localhost:8081/Service" );
    		serviceHost.Description.Behaviors.Find<ServiceDebugBehavior>().IncludeExceptionDetailInFaults = true;
    
    		serviceHost.Open();
    
    		using( var channelFactory = new ChannelFactory<ISubsetInterface>( new BasicHttpBinding(), "http://localhost:8081/Service") )
    		{
    			var client = channelFactory.CreateChannel();
    
    			client.InterestingMethod().Should().Be( "foo" );
    		}
    
    		serviceHost.Close();
    	}
    
    	[ServiceContract]
    	interface IServiceInterface
    	{
    		[OperationContract]
    		string InterestingMethod();
    		[OperationContract]
    		string UninterestingMethod();
    	}
    
    	[ServiceContract(Name = "IServiceInterface")]
    	interface ISubsetInterface
    	{
    		[OperationContract]
    		string InterestingMethod();
    	}
    
    	class Service : IServiceInterface
    	{
    		public string InterestingMethod() { return "foo"; }
    
    		public string UninterestingMethod() { throw new NotImplementedException(); }
    	}
    }
