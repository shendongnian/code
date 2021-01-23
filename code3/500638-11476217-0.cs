        [XmlRoot("UpdateOrderStatus")]
        public class UpdateOrderStatus
        {
            [XmlElement("Action")]
            public int Action { get; set; }
            private String valueField;
            [XmlElement("Value")]
            public XmlCDataSection Value
            {
                get
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    return xmlDoc.CreateCDataSection(valueField);
                }
                set
                {
                    this.valueField = value.Value;
                }
            }
        
            [XmlIgnore]
            public ShipmentInfo Shipment
            {
                get;
                set;
            }
        }
        [XmlRoot("ShipmentInfo")]
        public class ShipmentInfo
        {
            [XmlElement("Package")]
            public String Package { get; set; }
            [XmlElement("Header")]
            public String Header { get; set; }
        }
