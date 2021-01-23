    // load original XML from the stream
    XDocument loadedData = XDocument.Load(stream);
	
    // create a new parent XML structure (new root) and load the original nodes
    var newXml = new XDocument(new XElement("Histories"));
    newXml.Root.Add(loadedData.Root);
	
    // create the new node
    var NewNode = new XElement("History");
    var RecipentN = new XElement("RecipentName", "ABC");
    var RecipentNo = new XElement("RecipentNumber", "ABABAB");
    var Time = new XElement("TimeStamp", "Monday");
    var MessageBody = new XElement("Message", "23");
    NewNode.Add(RecipentN, RecipentNo, Time, MessageBody);	
    // add the new node
    newXml.Root.Add(NewNode);
    // save the stream
    newXml.Save(stream);
