	delegate void RefAction<T1, T2>(ref T1 arg1, T2 arg2);
	struct TestFields
	{
		public int MaxValue
		{
			get;
			set;
		}
	};
	static class Program
	{
		static void Main(string[] args)
		{
			var propertyInfo = typeof(TestFields).GetProperty("MaxValue");
			var propertySetter = (RefAction<TestFields, int>)Delegate.CreateDelegate(typeof(RefAction<TestFields, int>), propertyInfo.GetSetMethod());
			var fields = new TestFields { MaxValue = 1234 };
			propertySetter(ref fields, 5678);
			Console.WriteLine(fields.MaxValue);
		}
	}
