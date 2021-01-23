    [DataContract]
    public class SingleProductResult : AjaxResult
    {
        [DataMember]
        public Product Data { get; set; }
        [DataMember]
        public IList<int> ValidationErrors { get; set; }
    }
