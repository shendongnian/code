    // create a serializer for the root type above
    var serializer = new XmlSerializer(typeof (EmployeeConfiguration));
    // by default, the serializer will write out the "xsi" and "xsd" namespaces to any output.
    // you don't want these, so this will inhibit it.
    var namespaces = new XmlSerializerNamespaces(new [] { new XmlQualifiedName("", "") });
    serializer.Serialize(Console.Out, config, namespaces);
