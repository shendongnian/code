	internal class ClientFactory
	{
		public IServiceOld GetClient()
		{
			string service = ConfigurationManager.AppSettings["Service"];
			if(service == "Old")
				return new ClientOld();
			else if(service == "New")
				return new ClientNew();
			throw  new NotImplementedException();
		}
	}
