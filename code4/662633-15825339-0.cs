    [DataContract]
    public class Container
    {
        [DataMember(Order = 1)]
        public string displayFieldName { get; set; }
        [DataMember(Order = 2)]
        public FieldAliases fieldAliases { get; set; }
        [DataMember(Order = 3)]
        public string geometryType { get; set; }
        [DataMember(Order = 4)]
        public SpatialReference spatialReference { get; set; }
        [DataMember(Order = 5)]
        public fieldContainer fields { get; set; }
        [DataMember(Order = 6)]
        public Features features { get; set; }
    }
