    var values = new List<string>();
    using(var sr = new StreamReader(fileName))
    {
        string line;
        XmlDocument x = new XmlDocument();
        while((line = sr.ReadLine()) != null)
        {
            
            x.LoadXml(line);
            foreach(var node in x.GetElementsByTagName("Output"))
               values.Add(node.Attributes["GeneratedNumber"].Value);    
        }
    }
