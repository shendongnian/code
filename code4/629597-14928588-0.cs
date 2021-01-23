    XDocument document = XDocument.Load(@"C:\Sample_Xml\PriceData.xml");
    List<string> priceDataFile = new List<string>();
    var priceData = (from pd in document.Descendants("priceData")
                      select pd).ToList();
    foreach (XElement priceValue in priceData.Elements())
    {
        priceDataFile.Add(priceValue.FirstAttribute.Value.ToString());
    }
