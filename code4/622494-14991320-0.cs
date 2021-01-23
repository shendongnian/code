    [XmlRoot("product")]
    public class ProductDto
    {
        [XmlElement("productId")]
        public int ProductId { get; set; }
        [XmlElement("availability")]
        public AvailabilityDto Availability { get; set; }
        ...
    }
    [XmlRoot("availability")]
    public class AvailabilityDto
    {
        [XmlElement("inStock")]
        public bool InStock { get; set; }
        ...
    }
