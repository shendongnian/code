    namespace My.Domain
    {
      public class MyDataContext : IDisposable	{
		private MyDB _context;
		private bool _ownContext;
		public MyDataContext(){
			_context = new MyDB();
			_ownContext = true;
		}
		public MyDataContext(MyDB db)
		{
			_context = db;
			_ownContext = false;
		}
		public MyDB Context
		{
			get { if (_context == null) { _context = new MyDB(); _ownContext = true; } return _context; }
			set { _context = value; }
		}
		public bool OwnContext
		{
			get { return _ownContext; }
			set { _ownContext = value; }
		}
		public void Dispose()
		{
			if (_context != null && _ownContext)
				_context.Dispose();
		}
      }
    }
