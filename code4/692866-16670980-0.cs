    XDocument doc = XDocument.Parse("<xml content>");
    
    //finding element having 4 as ID
    XElement id4 = doc.Descendants().First(el => el.Attribute("ID").Value == "4");
                
    XElement parent = id4.Parent;
    parent.RemoveAll();
    parent.Add(id4);
