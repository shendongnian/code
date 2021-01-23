	public static class NNNNServiceExtensions
	{
		public static Task<ReturnType> MethodNameTaskAsync(this NNNNService service, A a)
		{
			if (service == null)
				throw new NullReferenceException();
				
				
			var tcs = new TaskCompletionSource<ReturnType>();
			
			EventHandlerType handler = null;
			handler = (s, o) =>
			{
				service.MethodNameCompleted -= handler;
				tcs.TrySetCompleted(o.Result);
			};
			
			service.MethodNameCompleted += handler;
			try
			{
				service.MethodNameAsync();
			}
			catch
			{
				service.MethodNameCompleted -= handler;
				throw;
			}
					
			return tcs.Task;
		}
	}
