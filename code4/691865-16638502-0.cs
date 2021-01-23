	public class Context: IDisposable
	{
		[ThreadStatic]
		static private Context _Current;
		static public Context Current
		{
			get
			{
				return _Current;
			}
		}
		private readonly Context _Previous;
		public Context(string id)
		{
			ID = id;
			_Previous = _Current;
			_Current = this;
		}
		public string ID
		{
			get;
			private set;
		}
		public void Dispose()
		{
			_Current = _Previous;
		}
	}
