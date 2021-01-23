	static void Main(string[] args)
	{
		var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "myCustomConfiguration.config");
		Dictionary<string, string> dictionary = GetNameValueCollectionSection("appSettings", filePath);
		//To get your key do dictionary["Foo"]
                Console.WriteLine(dictionary["Foo"]);
		
		Console.ReadLine();
	}
	private static Dictionary<string, string> GetNameValueCollectionSection(string section, string filePath)
	{
		var xDoc = new XmlDocument();
		var nameValueColl = new Dictionary<string, string>();
		var configFileMap = new ExeConfigurationFileMap { ExeConfigFilename = filePath };
		Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
		string xml = config.GetSection(section).SectionInformation.GetRawXml();
		xDoc.LoadXml(xml);
		XmlNode xList = xDoc.ChildNodes[0];
		foreach (XmlNode xNodo in xList.Cast<XmlNode>().Where(xNodo => xNodo.Attributes != null))
		{
			nameValueColl.Add(xNodo.Attributes[0].Value, xNodo.Attributes[1].Value);
		}
		return nameValueColl;
	}
