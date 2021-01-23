    public class PurchaseItem
    {
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlArray("FooCosts")]
        public Cost[] Costs { get; set; }
    }
    <?xml version="1.0" encoding="utf-16"?>
    <PurchaseItem xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
      <Name>Foo</Name>
      <FooCosts>
        <Cost>
          <Code>C#</Code>
          <Info>Awesome</Info>
        </Cost>
        <Cost>
          <Code>VB6</Code>
          <Info>:(</Info>
        </Cost>
      </FooCosts>
    </PurchaseItem>
