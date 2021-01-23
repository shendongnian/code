    // use built in serialization mechanism
    XmlSerializer mySerializer = new XmlSerializer(typeof(Speech));
    // Writing the file requires a TextWriter.
    TextWriter writer = new StreamWriter("test.xml");
    var speech = new Speech();
    var lang1 = new LanguageItem() { Id = 1, Language = "English", };
    var lang2 = new LanguageItem() { Id = 2, Language = "Slovenian", };
    speech.Items.Add(lang1);
    speech.Items.Add(lang2);
    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
    //Add an empty namespace and empty value
    ns.Add("", "");
    mySerializer.Serialize(writer, speech, ns);
    writer.Close();
