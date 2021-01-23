    // tasks = XDocument.root;
    public static void RemoveTasksAndSubTasks(XElement tasks, int id)
    {
      List<string> removeIDs = new List<string>();
      removeIDs.Add(id.ToString());
      while (removeIDs.Count() > 0)
      {
        // Find matching Elements to Remove
        // Check for Attribute, 
        // so we don't get Null Refereence Exception checking Value
        var matches = 
            tasks.Elements("Task")
                 .Where(x => x.Attribute("ID") != null
                             && removeIDs.Contains(x.Attribute("ID").Value));
        matches.Remove();
        // Find all elements with ParentID 
        // that matches the ID of the ones removed.
        removeIDs = 
            tasks.Elements("Task")
                 .Where(x => x.Attribute("ParentId") != null
                             && x.Attribute("ID") != null
                             && removeIDs.Contains(x.Attribute("ParentId").Value))
                 .Select(x => x.Attribute("ID").Value)
                 .ToList();
      }
    }
