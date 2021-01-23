    XDocument doc = XDocument.Parse(...);    
    StringBuilder sb = new StringBuilder(1000);
    foreach (XElement node in doc.Descendants("forecast_conditions"))
    {
        foreach(XElement innerNode in node.Elements())
        {
           sb.AppendFormat("{0},", innerNode.Attribute("data").Value);
        }
        //Remove trailing comma
        sb.Remove(sb.Length - 1, 1);
        sb.AppendLine();
    }
    File.WriteAllText(@"c:\temp.csv", sb.ToString());
