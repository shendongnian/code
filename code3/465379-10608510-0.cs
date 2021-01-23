    public static string SearchToChangeXML(string input, int changetype = 0)
	{
		//Replace -.- | no time, hope later more time to make better... But it works
		input = input.Replace("<_asd_cas01d0005p0000013303Response", "<_asd_cas01d0005p0000013203");
		input = input.Replace("</_asd_cas01d0005p0000013303Response>", "</_asd_cas01d0005p0000013203>");
		for (int i = 20; i <= 40; i++)
		{
			input = input.Replace("<Ec_" + i.ToString() + "Ki>", "<Ic_" + i.ToString() + "Ki>");
			input = input.Replace("</Ec_" + i.ToString() + "Ki>", "</Ic_" + i.ToString() + "Ki>");
			input = input.Replace("<Ec_" + i.ToString() + "Ki />", "<Ic_" + i.ToString() + "Ki />");
			input = input.Replace("<Ec_" + i.ToString() + "Ki/>", "<Ic_" + i.ToString() + "Ki/>");
		}
		XmlDocument xml = new XmlDocument();
		xml.LoadXml(input);
		XmlNode dp = xml.DocumentElement;
		for (int i = 0; i < dp.ChildNodes.Count; i++)
		{
			//Things i dont need (not all Variables are present in other Class)
			if (dp.ChildNodes[i].Name == "Ic_38Ki" || dp.ChildNodes[i].Name == "Ic_39Ki" || dp.ChildNodes[i].Name == "EtMessages" ||
					dp.ChildNodes[i].Name == "EvCeeRequestId" || dp.ChildNodes[i].Name == "EvStatusCode")
				dp.ChildNodes[i].RemoveAll();
		}
		using (var stringWriter = new StringWriter())
		using (var xmlTextWriter = XmlWriter.Create(stringWriter))
		{
			xml.WriteTo(xmlTextWriter);
			xmlTextWriter.Flush();
			return stringWriter.GetStringBuilder().ToString();
		}
	}
