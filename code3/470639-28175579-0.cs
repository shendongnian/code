    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
	public class InitialiseWithAttribute : Attribute
	{
		public string Id { get; private set; }
		public InitialiseWithAttribute(string id)
		{
			Id = id;
		}
	}
