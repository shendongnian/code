    var oldDoc = new XDocument();
    oldDoc.Add(new XElement("OldRoot"));
    var newDoc = new XDocument();
    newDoc.Add(new XElement("NewRoot"));
    oldDoc.Root.ReplaceWith(newDoc.Root);
