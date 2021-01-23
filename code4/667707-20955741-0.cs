	public void method1()
	{
		Ilist<string> testList = new IList<string>(){"1","2","3"};
		Parallel.ForEach(testList, ()=>
		{
			method2();
		});
	}
	public void method2()
	{
		// some other (plain old synchronous) code here
	}
