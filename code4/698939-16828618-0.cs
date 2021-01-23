	Class ClassA
	{
		public int IntA = 0;
		public int IntB = 5;
	}
	class ClassB
	{
		public static ClassA;
	}
	main
	{
		ClassB MyClassB;
		ClassB MySecondClassB;
		
		MySecndClassB.ClassA.IntA = 1; //The vale of 1 will be overwritten by
		MyClassB.ClassA.IntA = 5; //the value of 5 here, for all instances of ClassB.
		System.Diagnostics.Print(MySecndClassB.ClassA.IntA.ToString() + " - " + MyClassB.ClassA.IntA.ToString());
	}
