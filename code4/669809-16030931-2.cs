    var reader = XElement.Load(xmlfileaddress);
    
    foreach (var item in reader.Descendants("Item"))
    {
        var id = item.Element("GUID").Value;
        var name = item.Element("Title").Value;
        var type = item.Element("Type").Value;
        
        htmlstring += "<" + type + " id=" + id + " value=" + name + "/>" + name + "</" + type + ">";    
    }
