    [ServiceContract]
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
	public class MyService
	{
		[OperationContract]
		[WebInvoke(UriTemplate = "{personId}", Method = "GET")]
		public Person Get(string personId)
		{
			return new Person();
		}
	}
