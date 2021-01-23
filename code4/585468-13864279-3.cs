    public interface IStringToSignBuilder
    {
        string Build(ServiceSignatureDetails details);
    }
    /// <summary>
    /// Class is a data entity that defines the specific details
    /// required for a Service Signature
    /// </summary>
    public class ServiceSignatureDetails
    {
        public string HttpMethod { get; set; }
        public string ServiceClientId { get; set; }
        public string ServiceClientKey { get; set; }
        public string UriAbsolutePath { get; set; }
        public string DomainName { get; set; }
        public string CompanyName { get; set; }
        public string DateTimeStamp { get; set; }
        public string Data { get; set; }
    }
