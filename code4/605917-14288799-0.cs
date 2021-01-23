	public void Intercept(IInvocation invocation)
	{
		if (Log.IsDebugEnabled) Log.Debug(CreateInvocationLogString("Called", invocation));
		try
		{
			invocation.Proceed();
			if (Log.IsDebugEnabled)
			{
				var returnType = invocation.Method.ReturnType;
				if (returnType != typeof(void))
				{
					var returnValue = invocation.ReturnValue;
					if (returnType == typeof(Task))
					{
						Log.Debug("Returning with a task.");
					}
					else if (returnType.IsGenericType && returnType.GetGenericTypeDefinition() == typeof(Task<>))
					{
						Log.Debug("Returning with a generic task.");
						var task = (Task)returnValue;
						task.ContinueWith((antecedent) =>
											  {
												  var taskDescriptor = CreateInvocationLogString("Task from", invocation);
												  var result =
													  antecedent.GetType()
																.GetProperty("Result")
																.GetValue(antecedent, null);
												  Log.Debug(taskDescriptor + " returning with: " + result);
											  });
					}
					else
					{
						Log.Debug("Returning with: " + returnValue);
					}
				}
			}
		}
		catch (Exception ex)
		{
			if (Log.IsErrorEnabled) Log.Error(CreateInvocationLogString("ERROR", invocation), ex);
			throw;
		}
	}
