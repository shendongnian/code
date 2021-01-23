    ServiceContract]
        public interface IRestServiceImpl
        {
            [OperationContract]
            [System.ServiceModel.Web.WebInvoke(Method = "GET",ResponseFormat=System.ServiceModel.Web.WebMessageFormat.Xml, BodyStyle =System.ServiceModel.Web.WebMessageBodyStyle.Wrapped, UriTemplate = "xml/{id}")]
            string XMLData(string id);
            [OperationContract]
            [System.ServiceModel.Web.WebInvoke(Method = "GET", ResponseFormat = System.ServiceModel.Web.WebMessageFormat.Json, BodyStyle = System.ServiceModel.Web.WebMessageBodyStyle.Wrapped, UriTemplate = "json/{id}")]
            string JSONData(string id);
        }
    
    public class RestServiceImpl : IRestServiceImpl
        {
            #region IRestService Members
            public string XMLData(string id)
            {
                return "You Request Porduct" + ":"+id;
    
            }
            public string JSONData(string id)
            {
                return "Yor Request Product" +":"+ id;
            }
            #endregion
        }
