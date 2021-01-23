	class Myclass
	{
	};
	class ChildClass : MyClass
	{
	};
	template<typename T>
	class MockComposite
	{
	public:
		MockComposite(const T& objectToTest) { ... }
	};
