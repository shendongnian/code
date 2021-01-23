    [OperationContract]
    [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "/weather")]
    List<Weather> GetWeatherMethod(ZipCodeJSON zipJson);
    [DataContract]
    public class ZipCodeJSON
    {
        [DataMember]
        public string zip { get; set; }
    }
