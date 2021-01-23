	//Not XElement but XDocument
	XDocument doc = XDocument.Load(@"D:\test\test.xml");
	string abc, def;
	foreach (XElement elm in doc.Descendants().Elements("test"))
	{
		//Not elm.Element but elm.Attribute
		abc = elm.Attribute("att").Value;
		def = elm.Attribute("title").Value;
		Console.WriteLine(abc);
		Console.WriteLine(def);
	}
