    XElement allData = XElement.Load(dlg.FileName);
    if (allData != null)
    {
        IEnumerable<XElement> tasks = allData.Descendants("task");
        foreach (XElement task in tasks)
        {
            task.Attribute("name").Value;
            task.Attribute("start").Value;
            task.Attribute("finish").Value;
        }
    }
