    // The Model Object
    
    [Serializable]
    [XmlRoot("OutputItem")]
    [DataContractAttribute]
    public class MeterInfo
    {
        [XmlElement("ItemName")]
        [DataMemberAttribute] 
        public string Name { get; set; }
        
        [XmlArray("Fields")]
        [XmlArrayItem("Field", typeof(MyItemField))]
        public List<Fields> trendlines { get; set; }
    }
    
    
    
    // The Class that implement the contract
    [DataContract]
    public class ConsumptionService : IAnyContract
    {
        public MyItem GetItemXML(string id)
        {
           myItem mi = new myItem();
           //do some stuff to populate mi
           return mi;   
        }
     }
