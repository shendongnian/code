    string xml = 
    @"<Category id=""1"">
	<MyLines>
		<Line GroupID=""0"" Cache=""15"" />
	<Rect GroupID=""0"" Cache=""16""/>
	<Ellipse GroupID=""0"" Cache=""16""/>
	</MyLines>
    </Category>";
    void Main()
    {
        var doc = XDocument.Parse(xml);
	
        doc.Descendants("MyLines")
        .Elements()
        .Where(el => el.Attribute("Cache").Value == "16") 
        .ToList()
        .ForEach(el => el.Remove());
        doc.Root.ToString().Dump();
    }
