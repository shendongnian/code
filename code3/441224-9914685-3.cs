    [ServiceContract]
    public interface ISearch
    {
        [OperationContract]
        [WebGet(UriTemplate = "getProductList",  RequestFormat = WebMessageFormat.Xml, ResponseFormat WebMessageFormat.Xml)]
        Products GetProductList();
    }
