    XmlDocument doc = new XmlDocument();
    doc.Load("bookstore.xml");
    XmlNode root = doc.DocumentElement;
    // Add the namespace.
    XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
    nsmgr.AddNamespace("bk", "urn:newbooks-schema");
    // Select and display the first node in which the author's 
    // last name is Kingsolver.
    XmlNode node = root.SelectSingleNode(
    "descendant::bk:book[bk:author/bk:last-name='Kingsolver']", nsmgr);
    Console.WriteLine(node.InnerXml);
