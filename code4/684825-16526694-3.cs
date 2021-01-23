	[ComVisible (true)]
	[AsyncProtocol (Name = "http2", Description = "blah")]
	public class FilteredHttpProtocol :  IInternetProtocol, IInternetProtocolRoot
	{
		private IInternetProtocol _wrapped;
		private static int s_id = 0;
		private int _id = -1;
		private int _creatingTID = -1;
		private Control _dispatcher;
		public FilteredHttpProtocol (Control ctrl)
		{
		  _dispatcher = ctrl;
		  _id = s_id;
		  s_id++;
		  _creatingTID = Thread.CurrentThread.ManagedThreadId;
		  Debug.WriteLine ("#" + _id + " threadID: " + _creatingTID + " C'tor()");
		  _dispatcher.Dispatcher.Invoke (
			  () =>
			  {
				var originalHttpHandler = new OriginalHttpHandler();
				_wrapped = (IInternetProtocol) originalHttpHandler;
			  });
		}
		public void Start (string szURL, IInternetProtocolSink Sink, IInternetBindInfo pOIBindInfo, uint grfPI, uint dwReserved)
		{
		  Debug.WriteLine ("#" + _id + " URL: " + "\t" + szURL);
		  _dispatcher.Dispatcher.Invoke (
			  () =>
			  {
				Debug.WriteLine (
					"#" + _id + " original thread: " + _creatingTID + " calling thread " + Thread.CurrentThread.ManagedThreadId
					+ " Start() "
					+ Thread.CurrentThread.GetApartmentState());
				_wrapped.Start (szURL, Sink, pOIBindInfo, grfPI, dwReserved);
			  });
		}
		public void Continue (ref _tagPROTOCOLDATA pProtocolData)
		{
		  var _pProtocolData = pProtocolData;
		  _dispatcher.Dispatcher.Invoke (
			  () =>
			  {
				Debug.WriteLine (
					"#" + _id + " original thread: " + _creatingTID + " calling thread " + Thread.CurrentThread.ManagedThreadId + " Continue() "
					+ Thread.CurrentThread.GetApartmentState());
				_wrapped.Continue (ref _pProtocolData);
			  });
		  pProtocolData = _pProtocolData;
		}
		// ...
	}
