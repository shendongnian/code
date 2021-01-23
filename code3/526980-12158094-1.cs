    [DataContract]
    public class CarBookReq
    {
        [DataMember]
        public string RefNo { get; set; }
        [DataMember]
        public RateType MyProperty { get; set; }
            
    }
    [DataContract]
    public enum RateType
    {
        [EnumMember]
        silver,
        [EnumMember]
        gold,
        [EnumMember]
        platinum,
        [EnumMember]
        young,
        [EnumMember]
        youngplus
    }
