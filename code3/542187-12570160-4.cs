    [Serializable()]
    [System.Xml.Serialization.XmlInclude(typeof(CUST_HOLD))]
    [System.Xml.Serialization.XmlInclude(typeof(HOLD))]
    [System.Xml.Serialization.XmlType(TypeName = "Data2")]
    public class Root2
    {
                     
        [System.Xml.Serialization.XmlArrayItem("CUST_HOLD")]
        public CUST_HOLD[] CUST_HOLD;
       
         [System.Xml.Serialization.XmlArrayItem("HOLD")]
        public HOLD[] HOLD;
    }
     [Serializable()]
    [System.Xml.Serialization.XmlType("CUST_HOLD")]
    public class CUST_HOLD
    {
        
        public int i;
    }
    [Serializable()]
    [System.Xml.Serialization.XmlType("HOLD")]
    public class HOLD
    {
         
        public int i;
    }
