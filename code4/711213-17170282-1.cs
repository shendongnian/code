    var xml = @"<root>
        <item>
            <name>Item 1</name>
            <price>30.00</price>
        </item>
        <item>
            <name>Item 2</name>
            <price>55.00</price>
        </item>
    </root>";
    List<Item> items;
    var serializer = new XmlSerializer(typeof(List<Item>),
                                       new XmlRootAttribute("root"));
    
    using(var stream = new StringReader(xml))
    {
        items = (List<Item>)serializer.Deserialize(stream);
    }
    
    if(items != null)
    {
        foreach(var item in items)
        {
            Console.Write(item);
        }
    }
