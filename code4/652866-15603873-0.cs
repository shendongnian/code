	public interface IServiceProxyFactory<T>
	{
		// can have a better name like SetCredentials()
		T GetServiceProxy();
	}
		
	// Got rid of ServiceProxy1 class
	public partial class ServiceClient1 : IServiceProxyFactory<ServiceClient1>
	{
		public ServiceClient1 GetServiceProxy()
		{
			var client = this;
			// set credentials here
			//client.ClientCredentials = "";
			return client;
		}
	}
	public partial class ServiceClient2 : IServiceProxyFactory<ServiceClient2> { ... } 
    public static class ServiceMod<TClient>
        where TClient : class, ICommunicationObject, IServiceProxyFactory<TClient>, new()
    {
        public static TReturn Use<TReturn>(Func<TClient, TReturn> codeBlock)
        {
            TClient client = default(TClient);
            bool success = false;
            try
            {
                client = new TClient().GetServiceProxy();
                TReturn result = codeBlock(client);
                client.Close();
                success = true;
                return result;
            }
            finally
            {
                if (!success)
                {
                    client.Abort();
                }
            }
        }
    }
