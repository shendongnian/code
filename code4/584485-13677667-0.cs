    public void CreateXml(Dictionary<string, string> myNameValuePairs, string type)
    {
        XElement xml = new XElement("Transaction",
            new XElement("TransactionType", type));
        foreach (var key in names)
        {
            xml.Add(new XElement(key.Replace(" ", string.Empty), myNameValuePairs[key]));
         }
        xml.Save("C:\\Users\\PHWS13\\Desktop\\sample.xml");
    }
