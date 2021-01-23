		private static string GetElementPath(XElement element)
		{
			var parent = element.Parent;
			if(parent == null)
			{
				return element.Name.LocalName;
			}
			else
			{
				return GetElementPath(parent) + "->" + element.Name.LocalName;
			}
		}
		static void Main(string[] args)
		{
			var xml = @"
				<Foo>
					<Bar>3</Bar>
					<Foo>
						<Bar>10</Bar>
					</Foo>
				</Foo>";
			var xdoc = XDocument.Parse(xml);
			var dictionary = new Dictionary<string, string>();
			foreach(var element in xdoc.Descendants())
			{
				if(!element.HasElements)
				{
					var key = GetElementPath(element);
					dictionary[key] = (string)element;
				}
			}
			Console.WriteLine(dictionary["Foo->Bar"]);
		}
