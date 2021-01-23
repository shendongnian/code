	public class Program
	{
		static void Main(string[] args)
		{
			var program = new Program();
			program.SerializeObject();
		}
		public void SerializeObject()
		{
			Person nate = new Person {Name = "Nate"};
				nate.friends.Add(new Person() { Name = "Joe" });
			
			Person kendall = new Person() {Name = "Kendall"};
				kendall.friends.Add(new Person() {Name = "Bob"});
			
			nate.friends.Add(kendall);
			var x = new XmlSerializer(nate.GetType());
			x.Serialize(Console.Out, nate);
			Console.ReadLine();
		}
	}
	public class Person
	{
		[XmlElement]
		public string Name;
		[XmlArray] 
		public Friends friends = new Friends();
	}
	public class Friends : List<Person>
	{
		private List<Person> friends = new List<Person>();
	}
