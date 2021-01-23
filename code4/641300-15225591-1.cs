    var xDoc = // your XDocument
    var toDel = new List<XElement>();
    foreach(var el in xDoc.Root.Elements("Event").Where(e => e.Elements("SubEvent").All(xel => xel.Attribute("update").Value == "DATETIME")))
    {
    	toDel.Add(el);
    }
    toDel.ForEach(e => e.Remove());
