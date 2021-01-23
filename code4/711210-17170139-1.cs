        const string test = @"<root>
        <item>
            <name>Item 1</name>
            <price>30.00</price>
        </item>
        <item>
            <name>Item 2</name>
            <price>55.00</price>
        </item>
    </root>";
      var serializer = new XmlSerializer(typeof(ItemList));
      List<Item> result;
      using (var reader = new StringReader(test)) {
        result = (List<Item>)serializer.Deserialize(reader);
      }
