    var xDoc = // your XDocument
    var toDel = new List<XElement>();
    foreach(var el in xDoc.Root.Elements("Event"))
    {
    	if (el.Elements("SubEvent").All(xel => xel.Attribute("update").Value == "DATETIME"))
    	{
    		toDel.Add(el);
    	}
    }
    toDel.ForEach(e => e.Remove());
