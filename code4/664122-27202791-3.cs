	public class Consumer : IConsumer
	{
		private readonly ISomeObjectFactory someObjectFactory;
	
		public Consumer(ISomeObjectFactory someObjectFactory)
		{
			if (someObjectFactory == null)
				throw new ArgumentNullException("someObjectFactory");
			this.someObjectFactory = someObjectFactory; 
		}
		
		public void DoSomething(IState state)
		{
			var instance = this.someObjectFactory.Create(state);
			try
			{
				// Use the instance here.
			}
			finally
			{
				this.someObjectFactory.Release(instance);
			}
		}
	}
