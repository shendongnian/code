	XElement root = new XElement("root");
	foreach (var item in peopleList)
	{
		root.Add(new XElement("people",
									new XElement("name", item.Name),
									new XElement("age", item.Age)
								));			
	}
	Console.WriteLine (root.ToString());
