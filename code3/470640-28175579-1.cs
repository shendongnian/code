    	public static bool IsInitialisedWith(this string testName, string value)
		{
			bool result = false;
			Type testClassType = new StackFrame(1).GetMethod().DeclaringType;
			MethodInfo methodInfo = testClassType.GetMethod(testName);
			if (methodInfo != null)
			{
				InitialiseWithAttribute initialiseWithAttribute =
                    methodInfo.GetCustomAttribute<InitialiseWithAttribute>(true);
				if (initialiseWithAttribute != null)
				{
					result = initialiseWithAttribute.Id == value;
				}
			}
			return result;
		}
