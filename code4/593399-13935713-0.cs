    foreach (XmlNode node in OrderNodeList)
    {
        Console.WriteLine(node.Attributes.GetNamedItem("owner").Value);
        Console.WriteLine(node.Attributes.GetNamedItem("order_no").Value);
        Console.WriteLine(node.Attributes.GetNamedItem("profoma_po").Value);
        XmlNodeList OrderdNodeList = node.SelectNodes("/order_d");
        foreach (XmlNode orderd in OrderdNodeList)
        {
            Console.WriteLine("D " + orderd.Attributes.GetNamedItem("owner").Value);
            Console.WriteLine("D " + orderd.Attributes.GetNamedItem("order_no").Value);
            Console.WriteLine("D " + orderd.Attributes.GetNamedItem("item_no").Value);
        }
        Console.WriteLine("*****************new Line*******************");
    }
