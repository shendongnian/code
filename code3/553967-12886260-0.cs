	static Task<T> TaskFromEventHelper<T>(object target, string eventName, Delegate resultSetter)
	{
		var tcs				= new TaskCompletionSource<T>();
		var addMethod		= target.GetType().GetEvent(eventName).GetAddMethod();
		var delegateType	= addMethod.GetParameters()[0].ParameterType;
		var methodInfo		= delegateType.GetMethod("Invoke");
		var parameters		= methodInfo.GetParameters()
										.Select(a => Expression.Parameter(a.ParameterType))
										.ToArray();
		// building method, which argument count and
		// their types are not known at compile time
		var exp = // (%arguments%) => tcs.SetResult(resultSetter.Invoke(%arguments%))
			Expression.Lambda(
				delegateType,
				Expression.Call(
					Expression.Constant(tcs),
					tcs.GetType().GetMethod("SetResult"),
					Expression.Call(
						Expression.Constant(resultSetter),
						resultSetter.GetType().GetMethod("Invoke"),
						parameters)),
				parameters);
		addMethod.Invoke(target, new object[] { exp.Compile() });
		return tcs.Task;
	}
