    var doc = XDocument.Load(responseReader);
    XNamespace nsAtom = "http://www.w3.org/2005/Atom";
    XNamespace nsTag = "tag:foo.com,2008:/my/data";
    
    // get all entry nodes / use the atom namespace
    var entry = doc.Root.Elements(nsAtom + "entry");
    
    // get all StatusInfo elements / use the atom namespace
    var statusInfo = entry.Descendants(nsTag + "StatusInfo");
    
    // get all Status / use the tag namespace
    var status = statusInfo.Elements(nsTag + "Status");
    
    // get value of all Status
    var values = status.Select(x => x.Value.ToString()).ToList();
