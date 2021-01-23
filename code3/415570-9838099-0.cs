        public class OptionalOrder
        {
            // This field should not be serialized 
            // if it is uninitialized.
            public string FirstOrder;
            // Use the XmlIgnoreAttribute to ignore the 
            // special field named "FirstOrderSpecified".
            [System.Xml.Serialization.XmlIgnoreAttribute]
            public bool FirstOrderSpecified;
        }
