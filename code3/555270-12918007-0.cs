    static void Main(string[] args)
		{
			XDocument xdoc = new XDocument(
				new XElement("Root",
					DirToXml(new DirectoryInfo("C:\\MyFolder"))));
		}
		private static XElement DirToXml(DirectoryInfo dir)
		{
			return new XElement("Directory",
						new XAttribute("Name", dir.Name),
						dir.GetDirectories().Select(d => DirToXml(d)));
		}
