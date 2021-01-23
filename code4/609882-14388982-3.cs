	public class MyCustomSection : ConfigurationSection
	{
		[ConfigurationProperty("", IsDefaultCollection = true)]
		[ConfigurationCollection(typeof(MyElementCollection), AddItemName = "element")]
		public MyElementCollection Elements
		{
			get { return (MyElementCollection)this[""]; }
		}
	}
	public class MyElementCollection : ConfigurationElementCollection, IEnumerable<MyElement>
	{
		private readonly List<MyElement> elements;
		public MyElementCollection()
		{
			this.elements = new List<MyElement>();
		}
		protected override ConfigurationElement CreateNewElement()
		{
 			var element = new MyElement();
			this.elements.Add(element);
			return element;
		}
		protected override object GetElementKey(ConfigurationElement element)
		{
 			return ((MyElement)element).Name;
		}
		public new IEnumerator<MyElement> GetEnumerator()
		{
			return this.elements.GetEnumerator();
		}
	}
	public class MyElement : ConfigurationElement
	{
		[ConfigurationProperty("name", IsKey = true, IsRequired = true)]
		public string Name
		{
			get { return (string)this["name"]; }
		}
	}
