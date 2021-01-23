	public class Parent
	{
		public string Id {get; set;}
		
		public Parent(string id)
		{
			Id = id;
		}
	}
	
	public class Child : Parent
	{
		public string Name {get; set;}
		
		public Child(string id, string name) : base(id) // <-- call base constructor
		{
			Name = name;
		}
	}
