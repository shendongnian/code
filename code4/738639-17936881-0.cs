	class ServiceRun
	{
		private MyLibrary.LibraryContext _context;
		private Timer _timer;
		
		public ServiceRun()
		{
			_context = MyLibrary.Core.InitializeBaseData();
			_timer = new Timer(10000);
			_timer.OnTick+= ()=> MyLibrary.Core.DoAction(_context);
		}
	}
