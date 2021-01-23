    Order o = new Order();
    o.Positions.Add(new TextPosition() { Text = "This is Order No 123456" });
    o.Positions.Add(new ItemPosition() { ItemId = 14789, ItemName = "Product 1" });
    o.Positions.Add(new TextPosition());
    o.Positions.Add(new ItemPosition() { ItemId = 456, ItemName = "Product 2" });
    o.Positions.Add(new SumPosition() { Value = "123.45 USB" });
    XmlAttributeOverrides specific_attributes = new XmlAttributeOverrides();
    XmlAttributes attrs = new XmlAttributes();
    attrs.XmlElements.Add(new XmlElementAttribute(typeof(TextPosition)));
    attrs.XmlElements.Add(new XmlElementAttribute(typeof(ItemPosition)));
    attrs.XmlElements.Add(new XmlElementAttribute(typeof(SumPosition)));
    specific_attributes.Add(typeof(Order), "Positions", attrs);
    XmlSerializer ser = new XmlSerializer(typeof(Order), specific_attributes);
    using(MemoryStream mem_stream = new MemoryStream())
    {
       ser.Serialize(mem_stream, o);
       using (BinaryWriter bw = new BinaryWriter(new FileStream("orders.xml", FileMode.Create)))
       {
          bw.Write(mem_stream.ToArray());
       }
    }
