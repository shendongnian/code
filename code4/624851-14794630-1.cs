    // So we can find parent by ID
    var groupMap = root.Elements("group")
      .ToDictionary(e => (string)e.Attribute("id"), e => e);
    // Not ToList so we don't iterate modified collection
    foreach (var e in root.Elements().ToList()) {
      XElement parent;
      if (groupMap.TryGetValue((string)e.Attribute("parent") ?? "", out parent)) {
         // Unlike standard XML DOM,
         // make sure to remove XElement from parent first
         e.Remove();
    	 parent.Add(e);
      }
    }
    // LINQPad :-)
    // root.Dump();
