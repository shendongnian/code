    XmlSerializer xs = new XmlSerializer(typeof(SampleClass));
    XmlDeserializationEvents events = new XmlDeserializationEvents();
    events.OnUnknownAttribute = (sender, e) => Debug.WriteLine("Unknown Attributed");
    events.OnUnknownElement = (sender, e) => Debug.WriteLine("Unknwon Element");
    events.OnUnknownNode = (sender, e) => Debug.WriteLine("Unknown Node");
    events.OnUnreferencedObject = (sender, e) => Debug.WriteLine("Unreferenced Object");
    SampleClass cs_de = (SampleClass)xs.Deserialize(XmlReader.Create(new StringReader(xml)), events);
    Debug.WriteLine(cs_de.Foo);
    Debug.WriteLine(cs_de.Bar);
