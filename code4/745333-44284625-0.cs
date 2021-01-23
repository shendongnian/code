    XDocument doc = XDocument.Load("contosoBooks.xml");
    XmlSchemaSet set = new XmlSchemaSet();
    set.Add(null, "contosoBooks.xsd");
    StringBuilder errors = new StringBuilder();
    doc.Validate(set, (sender,args) => { errors.AppendLine(args.Exception.Message); });
    Console.WriteLine(errors);
