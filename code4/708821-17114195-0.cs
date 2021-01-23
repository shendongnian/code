    using System.Runtime.Serialization;
    namespace Client.Faults {
        public class InvalidRepresentationFault 
        {
            public InvalidRepresentationFault() {}
        }
        [DataContract(Namespace = Constants.Rm.Namespace)]
        public class RepresentationFailures
        {
            [DataMember()]
            public FailureDetail AttributeRepresentationFailure;
        [DataContract(Namespace = Constants.Rm.Namespace)]
        public class FailureDetail
        {
            [DataMember(Order = 1)]
            public string AttributeType;
            [DataMember(Order = 2)]
            public string AttributeValue;
            [DataMember(Order = 3)]
            public string AttributeFailureCode;
            [DataMember(Order = 4)]
            public string AdditionalTextDetails;
        }
        [DataMember]
        public string CorrelationId;
    }
