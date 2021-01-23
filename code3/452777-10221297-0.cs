	public static class RxPS
	{
		private static Dictionary<Type, object> _subjects
			= new Dictionary<Type, object>();
		
		public static IDisposable Subscribe<T>(Action<T> observer)
		{
			lock(_subjects)
			{
				if (!_subjects.ContainsKey(typeof(T)))
				{
					_subjects.Add(typeof(T), new Subject<T>());
				}
				return (_subjects[typeof(T)] as Subject<T>)
					.Subscribe(observer);
			}
		}
		
		public static void Publish<T>(T item)
		{
			lock(_subjects)
			{
				if (_subjects.ContainsKey(typeof(T)))
				{
					(_subjects[typeof(T)] as Subject<T>)
						.OnNext(item);
				}
			}
		}
	}
