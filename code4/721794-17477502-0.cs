	using System;
	using System.Reflection.Emit;
	public static class Reference
	{
		public static readonly int Size = new Func<int>(delegate()
		{
			var method = new DynamicMethod(string.Empty, typeof(int), null);
			var gen = method.GetILGenerator();
			gen.Emit(OpCodes.Sizeof, typeof(object));
			gen.Emit(OpCodes.Conv_I4);
			gen.Emit(OpCodes.Ret);
			return ((Func<int>)method.CreateDelegate(typeof(Func<int>)))();
		})();
	}
