	[DataContract]
	public class Person
	{
		private string m_name;
		[DataMember]
		public string Name
		{
			get { return m_name; }
			set { m_name = value; }
		}
	}
		private void Form1_Load(object sender, EventArgs e)
		{
			var person = new Person() {Name = "john"};
			var xs = new XmlSerializer(typeof(Person));
			var sw = new StreamWriter(@"c:\person.xml");
			xs.Serialize(sw, person);
		}
You can also read this: <a>http://msdn.microsoft.com/en-us/library/83y7df3e%28VS.71%29.aspx</a>
