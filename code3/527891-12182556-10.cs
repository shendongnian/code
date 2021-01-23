	public class Program
	{
		static void Main(string[] args)
		{
			var program = new Program();
			program.SerializeObject();
		}
		private int tierIndex = 1;
		public void SerializeObject()
		{
			var barCollection = new BarCollection();
				var bar1 = new Bar() { Name = "bar1" };
				barCollection.Add(bar1);
				var bar2 = new Bar() { Name = "bar2" };
				barCollection.Add(bar2);
					var bar3 = new Bar() { Name = "bar3" };
					bar2.BarCollection.Add(bar3);
					var bar4 = new Bar() { Name = "bar4" };
					bar2.BarCollection.Add(bar4);
				var bar5 = new Bar() { Name = "bar 5" };
				barCollection.Add(bar5);
				var bar6 = new Bar() { Name = "bar 6" };
				barCollection.Add(bar6);
					var bar7 = new Bar() { Name = "bar 7" };
					bar6.BarCollection.Add(bar7);
						var bar8 = new Bar() { Name = "bar 8" };
						bar7.BarCollection.Add(bar8);
			var x = new XmlSerializer(typeof(BarCollection));
			x.Serialize(Console.Out, barCollection);
			Console.WriteLine("\n");
			WriteCollection(barCollection);
			Console.ReadLine();
		}
		public void WriteCollection(BarCollection barCollection)
		{
			tierIndex++;
			foreach (Bar bar in barCollection)
			{
				Console.Write(new StringBuilder().Insert(0, "--", tierIndex) + "> ");
				Console.Write(bar.Name + "\n");
				WriteCollection(bar.BarCollection);
			}
			tierIndex--;
		}
	}
	public class BarCollection : ICollection
	{
		private readonly ArrayList barNodes = new ArrayList();
		public Bar this[int index]
		{
			get { return (Bar) barNodes[index]; }
		}
		public void CopyTo(Array a, int index)
		{
			barNodes.CopyTo(a, index);
		}
		public int Count
		{
			get { return barNodes.Count; }
		}
		public object SyncRoot
		{
			get { return this; }
		}
		public bool IsSynchronized
		{
			get { return false; }
		}
		public IEnumerator GetEnumerator()
		{
			return barNodes.GetEnumerator();
		}
		public void Add(Bar bar)
		{
			barNodes.Add(bar);
		}
		public void Add(Object bar)
		{
			barNodes.Add((Bar) bar);
		}
	}
	public class Bar
	{
		[XmlAttribute(AttributeName = "Name")]
		public string Name;
		[XmlArray(ElementName = "BarNodes", IsNullable = true)]
		public BarCollection BarCollection = new BarCollection();
	}
