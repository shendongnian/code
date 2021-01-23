    [DataContract]
    [KnownType(typeof(EndpointImplA))]
    [KnownType(typeof(EndpointImplB))]
    public class RegisterEndpointRequest : NotificationRegistrationServiceRequest
    {
        [DataMember]
        public IEndpoint Endpoint { get; set; }
    }
