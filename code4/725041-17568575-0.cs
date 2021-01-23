	class BaseClassB
	{
		public void methodA(ClassB myVar)
		{
			Console.WriteLine(myVar.varB);
			methodCommon(myVar);
		}
		public void methodA(ClassA myVar)
		{
			Console.WriteLine(myVar.varA);
			methodCommon(myVar);
		}
		public void methodCommon(BaseClassA myVar)
		{
		}
	}
