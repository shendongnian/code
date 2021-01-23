    [DataContract]
    public class BusinessFault
    {
        [DataMember]
        public BusinessFaultType Type { get; set; }
        [DataMember]
        public string Details { get; set; }
        [DataMember]
        public ErrorCode ErrorCode { get; set; }
        public BusinessFault(BusinessFaultType type, ErrorCode errorCode)
        {
            Type = type;
            ErrorCode = errorCode;
        }
        public BusinessFault(BusinessFaultType type, string details, ErrorCode errorCode)
            : this(type, errorCode)
        {
            Details = details;
        }
    }
