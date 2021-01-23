    static List<string> GetActionsForInterface(string interfaceName)
    {
      var doc = XDocument.Parse(xml);
      List<string> actionList = new List<string>();
      var actions = doc.Root
        .Elements("Interface")
        .Where(x => x.Element("Name").Value == interfaceName).
        Descendants("Response").Select(x => x.Value);
      foreach (var action in actions)
        actionList.Add(action);
      return actionList;
    }
    
