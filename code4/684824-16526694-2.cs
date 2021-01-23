    [ComVisible (true)]
    public class FilteredHttpProtocolFactory : IClassFactory
	{
		private readonly Control _ctrl;
		public FilteredHttpProtocolFactory ()
		{
		  _ctrl = new Control();
		}
		public void CreateInstance (object pUnkOuter, Guid riid, out object ppvObject)
		{
		  ppvObject = new FilteredHttpProtocol(_ctrl);
		}
		public void LockServer (bool fLock)
		{
		}
	}
