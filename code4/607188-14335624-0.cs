	public class ReflectionHelper<T>
	{
		public MethodInfo GetMethod<TA1>(Expression<Func<T, Func<TA1>>> expr)
		{
			return ((MethodCallExpression)expr.Body).Method;
		}
		public MethodInfo GetMethod<TA1, TA2>(Expression<Func<T, Action<TA1, TA2>>> expr)
		{
			return ((MethodCallExpression)expr.Body).Method;
		}
		public MethodInfo GetMethod<TA1, TA2, TA3>(Expression<Func<T, Action<TA1, TA2, TA3>>> expr)
		{
			return ((MethodCallExpression)expr.Body).Method;
		}
		. . . // And more
	}
