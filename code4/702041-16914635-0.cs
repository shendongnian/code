    public class PurchaseItem
    {
        [XmlElement("Name")]
        public string Name { get; set; }
        public Cost[] Costs { get; set; }
    }
