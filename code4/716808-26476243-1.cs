    [XmlRoot("serviceResponse", Namespace="http://www.yale.edu/tp/cas")]
    public class ServiceResponse
    {
        [XmlElement("authenticationSuccess")]
        public CASAuthenticationSuccess Success { get; set; }
        [XmlElement("authenticationFailure")]
        public CASAuthenticationFailure Failure { get; set; }
    }
