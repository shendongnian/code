	class Myclass
	{
	}
	class ChildClass : MyClass
	{
	}
	class MockComposite<T> where T : MyClass
	{
		public MockComposite(T objectToTest) { ... }
	}
