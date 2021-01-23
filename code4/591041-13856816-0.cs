	void Main()
	{
		// some demo code
		var items = new CollectionOf<A>(); // create list of A elements
		items.Add(new A() { myProperty = "Hello" }); // create object of A and add it to list
		items.Add(new A() { myProperty = "World" }); // create object of A and add it to list
		foreach(var item in items)
		{
			Console.WriteLine(item.myProperty);
		}
	}
	
	// this is the collection class you asked for
	public class CollectionOf<U>: List<U>
	where U: A
	{
		// collection class enumerating A
		// note you could have used IEnumerable instead of List but then
		// you'd have to implement it first. List already implements everything
		// needed to enumerate (such as .Add(...))
	}
	
	public class A: IBase
	{
		// class A that implements IBase
		public string myProperty { get; set; }
	}
	
	public interface IBase {
		// some inteface
		string myProperty { get; set; }
	}
