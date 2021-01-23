	public class Parent
	{
		public Parent(string name, string city)
		{
		   Name = name;
		   City = city;
		}
		public string Name { get; set; }
		public string City { get; set; }
	}
	public class Child : Parent
	{
		public Child(string name, string city, int age) : base(name, city)
		{
		   Age = age;
		}
		public int Age { get; set; }
	} 
