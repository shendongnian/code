	public class CreateDelegateTest
	{
		public static Func<TResult> GetFunctionDelegate<TResult>()
		{
			var methodInfo = typeof(CreateDelegateTest).GetMethod("FunctionMethod")
													   .MakeGenericMethod(typeof(TResult));
			return (Func<TResult>)Delegate.CreateDelegate(typeof(Func<TResult>), methodInfo);
		}
		public static Action<T> GetActionDelegate<T>()
		{
			var methodInfo = typeof(CreateDelegateTest).GetMethod("ActionMethod")
													   .MakeGenericMethod(typeof(T));
			return (Action<T>)Delegate.CreateDelegate(typeof(Action<T>), methodInfo);
		}
	}
