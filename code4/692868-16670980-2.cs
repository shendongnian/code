    XDocument doc = XDocument.Parse("<xml content>");
    
    //finding element having 4 as ID
    XElement id4 = doc.Descendants().First(el => el.Attribute("Id").Value == "4");
    id4.RemoveNodes();
    XElement parent = id4.Parent;
    parent.RemoveNodes();
    parent.Add(id4);
