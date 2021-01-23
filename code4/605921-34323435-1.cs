    class TestInterceptor : AsyncInterceptor
	{
		protected override async Task<Object> InterceptAsync(object target, MethodBase method, object[] arguments, Func<Task<object>> proceed)
		{
			await Task.Delay(5000);
			var result = await proceed();
			return DateTime.Now.Ticks % 2 == 0 ? 10000 :result;
		}
	}
