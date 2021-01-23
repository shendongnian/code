    // The Model Object
    
    [Serializable]
    [XmlRoot("OutputItem")]
    [DataContractAttribute]
    public class MyObject
    {
        [XmlElement("ItemName")]
        [DataMemberAttribute] 
        public string Name { get; set; }
        
        [XmlArray("DummyItems")]
        [XmlArrayItem("DummyItem", typeof(MyItemField))]
        public List<Fields> DummyItem { get; set; }
    }
    
    
    
    // The Class that implement the contract
    [DataContract]
    public class ConsumptionService : IAnyContract
    {
        public MyObject GetItemXML(string id)
        {
           MyObject mo = new MyObject();
           //do some stuff to populate mi
           MyObject mo;   
        }
     }
