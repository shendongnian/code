		private ConcurrentBag<object> _results;
		public object[] MultiThreadMethod(string[] inputs)
		{
			_results = new ConcurrentBag<object>();
			var tasks = new Task[inputs.Length];
			for (int i = 0; i < inputs.Length; i++)
			{
				tasks[i] = Task.Factory.StartNew(() => DoWork(inputs[i]));
			}
			Task.WaitAll(tasks);
			return _results.ToArray();
		}
		private void DoWork(string item)
		{
			_results.Add(SomeMethod(item));
		}
