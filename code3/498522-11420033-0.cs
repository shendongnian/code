    XElement allData = XElement.Load(dlg.FileName);
    if (allData != null)
    {
      var tasks = allData.Descendants("task")
                         .Where(e => e.Attribute("name") != null
                                     && (e.Attribute("start") != null
                                         || e.Attribute("finish") != null))
                         .Select(e => new 
                         {
                           Name = e.Attribute("name").Value,
                           Start = e.Attribute("start").Value,
                           Finish = e.Attribute("finish").Value,
                         });
      foreach(var task in tasks)
      {
        // task.Name will have a value
        // task.Start and/or task.Finish will have a value.
      }
    }
