    public void CreateXml(string[] names, string[] values, string type)
    {
        XElement xml = new XElement("Transaction",
            new XElement("TransactionType", type));
        foreach (var i = 0; i < names.length; i++)
        {
            xml.Add(new XElement(names[i].Replace(" ", string.Empty), values[i]));
        }
        xml.Save("C:\\Users\\PHWS13\\Desktop\\sample.xml");
    }
