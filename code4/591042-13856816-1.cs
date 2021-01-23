	void Main()
	{
		var items = new CollectionOf<IBase>(); // create list of IBase elements
		items.Add(new A() { myProperty = "Hello" }); // create object of A and add it to list
		items.Add(new B() { myProperty = "World" }); // create object of B and add it to list
		foreach(var item in items)
		{
			Console.WriteLine(item.myProperty);
		}
	}
	
	// this is the collection class you asked for
	public class CollectionOf<U>: List<U>
	where U: IBase
	{
		// collection class enumerating A
		// note you could have used IEnumerable instead of List
	}
	
	public class A: IBase
	{
		// class A that implements IBase
		public string myProperty { get; set; }
	}
	public class B: IBase
	{
		// class B that implements IBase too
		public string myProperty { get; set; }
	}
	
	public interface IBase {
		// some inteface
		string myProperty { get; set; }
	}
