    XmlDocument x = new XmlDocument();
    x.LoadXml("<Output Change=\"12.13\" GeneratedNumber=\"120\" Total=\"99.21\" />");
    Console.WriteLine(x.GetElementsByTagName("Output")[0]
                          .Attributes["GeneratedNumber"].Value);
    Console.ReadLine();
