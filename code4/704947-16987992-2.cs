    XDocument xdoc = XDocument.Load("UserClassDictionary.xml");
    Dictionary<string, User> users = 
         xdoc.Root.Elements()
             .Select(u => new User {
                 Name = u.Name.LocalName,
                 ControlNumber = u.Elements().Select(cn => (int)cn).ToList()
              })
             .Where(u => ControlNumber.Any())
             .ToDictionary(u => u.Name);
