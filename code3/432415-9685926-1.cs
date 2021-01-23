    XmlSerializerNamespaces _namespaces = new XmlSerializerNamespaces();
    _namespaces.Add(string.Empty, string.Empty);
    SomeObject sm = new SomeObject();
    sm.arrayItems.Add(new arrayItem() { foo = "foo1" });
    sm.arrayItems.Add(new arrayItem() { foo = "foo2" });
    sm.item1 = "item1";
    sm.thing1 = "thing1";
    _xmlSerializer = new XmlSerializer(typeof(SomeObject));
    //writer is XmlWriter which writes data to response stream
    _xmlSerializer.Serialize(writer, sm, _namespaces);
