	public static class ProjectExtensions
	{
		public static Task<T> Interceptor<T>(this Task<T> task)
		{
			Task<T> continuation = task.ContinueWith<T>(t =>
				{
				if(someCondition)
				{
					throw new Exception("Error");
				}
				return t.Result;
			});
			return continuation;
		}
	}
