	static void MethodA()
	{
		using (new Context("A"))
		{
			SharedMethod();
		}
	}
	static void MethodB()
	{
		using (new Context("B"))
		{
			SharedMethod();
		}
	}
	static void SharedMethod()
	{
		Console.WriteLine(Context.Current.ID);
	}
