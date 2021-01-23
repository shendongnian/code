		public static InvokeDLLResult<T> InvokeDLL<T>(string strDllName, string strNameSpace,
							 string strClassName, string strMethodName,
							 ref object[] parameters,
							 ref string strInformation,
							 bool bWarnings = false)
		{
			try
			{
				// Check if user has access to requested .dll.
				if (!File.Exists(Path.GetFullPath(strDllName)))
				{
					strInformation = String.Format("Cannot locate file '{0}'!",
															 Path.GetFullPath(strDllName));
					return InvokeDLLResult<T>.Failure;
				}
				else
				{
					// Execute the method from the requested .dll using reflection.
					Assembly DLL = Assembly.LoadFrom(Path.GetFullPath(strDllName));
					Type classType = DLL.GetType(String.Format("{0}.{1}", strNameSpace, strClassName));
					if (classType != null)
					{
						object classInstance = Activator.CreateInstance(classType);
						MethodInfo methodInfo = classType.GetMethod(strMethodName);
						if (methodInfo != null)
						{
							object result = null;
							result = methodInfo.Invoke(classInstance, new object[] { parameters });
							return new InvokeDLLResult<T>(true, (T) Convert.ChangeType(result, methodInfo.ReturnType));
						}
					}
					// Invocation failed fatally.
					strInformation = String.Format("Could not invoke the requested DLL '{0}'! " +
															 "Please insure that you have specified the namespace, class name " +
															 "method and respective parameters correctly!",
															 Path.GetFullPath(strDllName));
					return InvokeDLLResult<T>.Failure;
				}
			}
			catch (Exception eX)
			{
				strInformation = String.Format("DLL Error: {0}!", eX.Message);
				if (bWarnings)
					Debug.WriteLine(eX.Message);
				return InvokeDLLResult<T>.Failure;
			}
		}
		public class InvokeDLLResult<T>
		{
			public InvokeDLLResult(bool success, T result)
			{
				Success = success;
				Result = result;
			}
			public bool Success { get; private set; }
			public T Result { get; private set; }
			public static InvokeDLLResult<T> Failure = new InvokeDLLResult<T>(false, default(T));
		}
