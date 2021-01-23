    [DataContract]
    public class OrderLineItem : IExtensibleDataObject
    {
        ExtensionDataObject IExtensibleDataObject.ExtensionData { get; set; }
        [DataMember]
        public Guid LineItemID { get; set; }
        [DataMember(IsRequired = true, EmitDefaultValue=false)]
        public string ProductID { get; set; }
        [DataMember(IsRequired = true, EmitDefaultValue=false)]
        public decimal Quantity { get; set; }
        [DataMember(IsRequired = false, EmitDefaultValue = false)]
        public bool IsValid { get; set; }
        [OnDeserializing]
        void BeforeDeserialization(StreamingContext ctx)
        {
            this.IsValid = false;
        }
    }
