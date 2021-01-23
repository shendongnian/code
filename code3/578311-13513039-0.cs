	public class A { }
	public class U<T> {
		public T X { get; set; }
	}
	static void Main(string[] args) {
		Type a = typeof(A);
		Type u = typeof(U<>);
		dynamic uOfA = Activator.CreateInstance(u.MakeGenericType(a));
		uOfA.X = new A();
		Console.WriteLine(uOfA.GetType());
		Console.WriteLine(uOfA.X.GetType());
	}
