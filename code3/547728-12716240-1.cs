    XDocument xDoc = XDocument.Parse(xml);
    List<CreditCardBrand> brands =
                xDoc.Descendants("Brand")
                .Select(br => new CreditCardBrand()
                {
                    Type = br.Attribute("type").Value,
                    Bins = br.Descendants("Bin")
                                .Select(b => new CreditCardBin(){
                                    Enabled = (bool)b.Attribute("enabled"),
                                    Value = b.Attribute("value").Value,
                                })
                                .ToList()
                })
                .ToList();
--
    public class CreditCardBrand
    {
        public string Type { get; set; }
        public List<CreditCardBin> Bins { get; set; }
    }
    public class CreditCardBin
    {
        public string Value { get; set; }
        public bool Enabled { get; set; }
    }
