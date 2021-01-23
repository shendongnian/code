    public object[] MultiThreadMethod(string[] inputs)
		{
			var tasks = new Task<object>[inputs.Length];
			for (int i = 0; i < inputs.Length; i++)
			{
				tasks[i] = Task<object>.Factory.StartNew(() => DoWork(inputs[i]));
			}
	
			Task.WaitAll(tasks);
			return tasks.Select(task => task.Result).ToArray();
		}
		private object DoWork(string item)
		{
			return SomeMethod(item);
		}
