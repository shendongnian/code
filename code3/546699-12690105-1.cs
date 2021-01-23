    for (int i = 0; i < options.NumberOfThreads; i++)
				{
					tasks[i] = Task.Factory.StartNew(() =>
						{
							using (Isolated<TesterInvoker> isolated = new Isolated<TesterInvoker>())
							{
								isolated.Value.Invoke();
							}
						});					
				}
    private class TesterInvoker : MarshalByRefObject
		{
			public void Invoke()
			{
				// do something
			}
		}
		
		private class Isolated<T> : IDisposable 
			where T : MarshalByRefObject
		{
			private AppDomain _domain;
			private T _value;
			public Isolated()
			{
				Type type = typeof(T);
				_domain = AppDomain.CreateDomain("Isolated:" + GetHashCode(),
				   null, AppDomain.CurrentDomain.SetupInformation);
				_value = (T)_domain.CreateInstanceAndUnwrap(type.Assembly.FullName, type.FullName);
			}
			public T Value
			{
				get
				{
					return _value;
				}
			}
			public void Dispose()
			{
				if (_domain != null)
				{
					AppDomain.Unload(_domain);
					_domain = null;
				}
			}
		}
