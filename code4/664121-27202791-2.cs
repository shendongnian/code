	public ISomeObjectFactory
	{
		ISomeObject Create();
		void Release(ISomeObject someObject);
	}
    public class SomeObjectFactory
        : ISomeObjectFactory
    {
		//private readonly IAclModule aclModule;
	
	    // Inject dependencies at application startup here
        //public SiteMapPluginProviderFactory(
        //    IAclModule aclModule
        //    )
        //{
        //    if (aclModule == null)
        //        throw new ArgumentNullException("aclModule");
        //
        //    this.aclModule = aclModule;
        //}
        public ISomeObject Create(IState state)
        {
			return new SomeObject(state);
            // return new SomeObject(state, this.aclModule);
        }
		
		pubic void Release(ISomeObject someObject)
		{
			var disposable = someObject as IDisposable;
			if (disposable != null)
			{
				disposable.Dispose();
			}
		}
    }
