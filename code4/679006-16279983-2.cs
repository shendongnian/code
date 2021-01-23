	class TestParent
	{
		public RootProperty<int> MyInt { get; private set; }
		
		public TestParent()
		{
			MyInt = new RootProperty<int>();
		}
		
	}
	class TestChild
	{
		public InheritedProperty<int> MyInt { get; private set; }
		
		public TestParent(TestParent parent)
		{
			MyInt = new InheritedProperty<int>(parent.MyInt);
		}
	}
