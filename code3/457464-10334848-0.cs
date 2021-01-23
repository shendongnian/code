	public static class MethodEx
	{
		public static void RunMethod(
             this object target,
             string methodName,
             params object[] values)
		{
			var type=target.GetType();
			var mi = 
              type.GetMethod(methodName,values.Select(v=>v.GetType()).ToArray());
			mi.Invoke(target,values);
		}
	}
