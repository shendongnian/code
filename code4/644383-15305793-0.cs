    public class OrderedItem
    {
        [XmlElement(Namespace = "http://www.cpandl.com")]
        public string ItemName;
        [XmlElement(Namespace = "http://www.cpandl.com")]
        public string Description;
        [XmlElement(Namespace = "http://www.cohowinery.com")]
        public decimal UnitPrice;
        [XmlElement(Namespace = "http://www.cpandl.com")]
        public int Quantity;
        [XmlElement(Namespace = "http://www.cohowinery.com")]
        public decimal LineTotal;
    
        // A custom method used to calculate price per item.
        public void Calculate()
        {
            LineTotal = UnitPrice * Quantity;
        }
    }
