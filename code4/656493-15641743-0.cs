	void Main()
	{
		string str = "<ABCMSG><t>ACK</t><t>AAA0</t><t>BBB1</t></ABCMSG>"; 
		XmlDocument doc = new XmlDocument();
		doc.LoadXml(str);
		var t = doc.GetElementsByTagName("t");
		Console.WriteLine(t[1].InnerText);
		Console.WriteLine(t[2].InnerText);
	}
