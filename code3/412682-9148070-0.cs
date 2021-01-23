    XDocument doc = XDocument.Load("your XML");
    var device = doc.Descendants("device").Select(item => item).Where(
                            item => item.Attribute("name").Value.ToString().Equals("some name")).FirstOrDefault();
        
    if(null != device)
    {
        var items = device.Attributes().Select(item => item).Where(item =>  item.Value == "True");
        if(null != items)
        {
            //you can also customize name according to your needs here
            yourListBox.AddRange(items.Select( item => item.Name.ToString() ).ToList());
        }
    }
