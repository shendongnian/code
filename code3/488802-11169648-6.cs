    var speech = new Speech();
    var lang1 = new LanguageItem() { Id = 1, Language = "English", };
    var lang2 = new LanguageItem() { Id = 2, Language = "Slovenian", };
    speech.Items.Add(lang1);
    speech.Items.Add(lang2);
     // do not want xml namespaces in the output:
     XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
     //Add an empty namespace and empty value
     ns.Add("", "");
    mySerializer.Serialize(writer, speech, ns);
    writer.Close();
