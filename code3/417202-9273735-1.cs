        [ServiceContract]
    public interface ICrossDomainService
    {
        [OperationContract, WebGet(UriTemplate = "/clientaccesspolicy.xml")]
        Stream GetClientAccessPolicy();
        [OperationContract, WebGet(UriTemplate = "/crossdomain.xml")]
        Stream GetCrossDomainPolicy();
    }
