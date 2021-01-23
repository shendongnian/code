	class A<T>			// concrete generic type
	{
	}
	abstract class B<T>	// abstract generic type i.e. not concrete
	{
	}
	A<int> a = new A<int>();
	// not possible: B<int> b = new B<int>();
	bool a1 = typeof(A<>).IsAbstract,		// false
		a2 = typeof(A<int>).IsAbstract,		// false
		b1 = typeof(B<>).IsAbstract,		// true
		b2 = typeof(B<int>).IsAbstract;		// true
