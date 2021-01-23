	var s = @"
	<Data>
		<Description>MASTER</Description>
		<Data>
			<Description>Parent1</Description>
			<Data id=""GUID1"" Description=""THIS IS A TEST"" />
			<Data id=""GUID2"" Description=""THIS IS A TEST"" />
			<Data id=""GUID3"" Description=""THIS IS A TEST"" />
		</Data>
		<Data>
			<Description>Parent2</Description>
			<Data id=""GUID4"" Description=""THIS IS A TEST"" />
			<Data id=""GUID5"" Description=""THIS IS A TEST"" />
		</Data>
		<Data id=""GUID6"" Description=""THIS IS A TEST"" />
	</Data>";
	
	var doc = XElement.Load(new StringReader(s));
	
	var desiredGuids = new List<string>{ "GUID1", "GUID6" };
	
	var result = (from data in doc.Descendants("Data")
				where data.Attribute("id") != null && desiredGuids.Contains((string)data.Attribute("id"))
				select new { 
					Id = data.Parent.Element("Description").Value + "." + (string)data.Attribute("id"),
					Description = (string)data.Attribute("Description"),
					Parent = data.Parent.Element("Description").Value
				});
				
	foreach (var element in result)
	{
		Console.WriteLine("{0} {1}", element.Id, element.Description);
	}
