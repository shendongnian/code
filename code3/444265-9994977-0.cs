    [DataContract(Namespace = "blah")]
    public class Item : IExtensibleDataObject
    {
        [DataMember(Order = 0)]
        public int Index { get; set; }
    
        [DataMember(Order = 1)]
        public ItemSourcesCollection Sources { get; set; }
    }
