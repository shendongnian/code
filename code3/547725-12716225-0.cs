    [XmlRoot("Brands")]
    public class CreditCardBrand
    {
        [XmlElement("Brand")]
        public CreditCardBrandCollection[] brandsCollection { get; set; }
    }
