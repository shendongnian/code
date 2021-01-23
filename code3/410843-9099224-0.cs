    [Test]
    public void X()
    {
        const string xml = "<Details><CreditCard cardnum=\"1234567890123456\" ccv=\"123\" exp=\"0212\" cardType=\"1\" name=\"joe\" /><donotfind>333</donotfind></Details>";
            
        var doc = new XmlDocument();
        doc.LoadXml(xml);
        Console.WriteLine(doc.Name);;
        foreach(XmlNode x in doc.ChildNodes)
        {
            ExploreNode(x);
        }
    }
    void ExploreNode(XmlNode node)
    {
        Console.WriteLine(node.Name);
        if (node.Attributes != null)
        {
            foreach (XmlAttribute attr in node.Attributes)
            {
                Console.WriteLine("\t{0} -> {1}", attr.Name, attr.Value);
                if (attr.Value.Length == 16 && Regex.IsMatch(attr.Value, @"\d{16}"))
                {
                    Console.WriteLine("\t\tCredit Card # found!");
                }
            }
        }
        foreach (XmlNode child in node.ChildNodes)
        {
            ExploreNode(child);
        }
    }
