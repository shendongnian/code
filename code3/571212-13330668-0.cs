		private static void Main(string[] args)
		{
			//string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			//XDocument xDoc = XDocument.Load(path + "\\Student Data\\data.xml");
			XDocument xDoc = XDocument.Load(AppDomain.CurrentDomain.BaseDirectory + "Customers.xml");
			IEnumerable<XElement> xElements = xDoc.Descendants("Person");
			foreach (XElement element in xElements)
			{
				foreach (XAttribute attribute in element.Attributes())
				{
					Console.WriteLine(attribute);
				}
				Console.WriteLine("-------------------------------------------");
			}
			Console.ReadLine();
		}
