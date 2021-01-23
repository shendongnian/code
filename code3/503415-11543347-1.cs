    Dictionary<string, string> dictionary =    new Dictionary<string, string>();
    
    var path = Server.MapPath("~/Content/pairs.xml");
    XElement elm = XElement.Load(path);
    //you can also load the XML from a stream /Textreader etc..
    if (elm != null)
    {       
        foreach (var page in elm.Elements("page"))
        {
            var title = page.Element("titel").Value;
            var url = page.Element("url").Value;
            dictionary.Add(title, url);
        }
    }
    //dictionary is filled now
