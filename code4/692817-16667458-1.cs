    public class ISomeFactory { ... }
	
	public class DefaultSomeFactory: ISomeFactory { ... }
	
	public class ClientClass
	{
	    public ISomeFactory FactoryOfSome  // Right place for dependency injection
		{
		    get
			{
			    if (_fact == null)
				    _fact = new DefaultFactory();
			    return _fact;
			}
			set { _fact = value; }
		}
		private ISomeFactory _fact;
	}
