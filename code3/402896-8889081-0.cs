        string xml = "<GroupBy Collapse=\"TRUE\" GroupLimit=\"30\"><FieldRef Name=\"Department\" /></GroupBy><OrderBy> <FieldRef Name=\"Width\" /></OrderBy>";
        xml = "<root>" + xml + "</root>";
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xml);
        foreach (XmlNode node in doc.GetElementsByTagName("FieldRef"))
            Console.WriteLine(node.Attributes["Name"].Value);
