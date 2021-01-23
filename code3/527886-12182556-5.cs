    public class Program
	{
		static void Main(string[] args)
		{
			var program = new Program();
			program.SerializeObject();
		}
		public void SerializeObject()
		{
			Bar bar0 = new Bar();
				bar0.Add(new Bar() { Name = "Bar1" });
				bar0.Add(new Bar() { Name = "Bar2" });
			Bar bar3 = new Bar() {Name = "Bar3"};
				bar3.Add(new Bar() { Name = "Child0 To bar3" });
				bar3.Add(new Bar() { Name = "Child1 To bar3" });
			
			bar0.Add(bar3);
			var x = new XmlSerializer(bar0.GetType());
			x.Serialize(Console.Out, bar0);
			Console.ReadLine();
		}
	}
	public class Bar
	{
		[XmlAttribute(AttributeName = "Name")]
		public string Name;
		[XmlArray(ElementName = "BarNodes", IsNullable = true)]
		public List<Bar> barNodes = new List<Bar>();
		public void Add(Object obj)
		{
			
		}
		public void Add(Bar item)
		{
			barNodes.Add(item);
		}
		public void Clear()
		{
			barNodes.Clear();
		}
		public IEnumerator GetEnumerator()
		{
			return barNodes.GetEnumerator();
		}
	}
