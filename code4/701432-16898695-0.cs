    var namespaceManager = new XmlNamespaceManager(x.NameTable);
    namespaceManager.AddNamespace("defaultNS", "https://ww.ggg.com");
            
    var result = x.SelectSingleNode("//defaultNS:InResponse", namespaceManager).InnerText;
    Console.WriteLine (result); //prints Error
