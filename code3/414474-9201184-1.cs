    [WebInvoke(UriTemplate = "/cust_key/{key}/prod_id/{id}", 
           Method = "POST",
           BodyStyle = WebMessageBodyStyle.Bare, 
           RequestFormat = WebMessageFormat.Xml, 
           ResponseFormat = WebMessageFormat.Xml)]  
    //Almost exacely the same except String is now Product in the method Parameters
    Stream GetData(string key, string id, Product data);
    [DataContract(Namespace = "")]
    public class Prodect
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public string price { get; set; }
    }
