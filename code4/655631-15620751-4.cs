    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebInvoke(Method="GET", BodyStyle=WebMessageBodyStyle.Bare, ResponseFormat=WebMessageFormat.Json)]
        jqGridModel<GridListItem> GetData();
        [OperationContract]
        [WebInvoke(Method="POST", BodyStyle=WebMessageBodyStyle.WrappedRequest,  RequestFormat=WebMessageFormat.Json)]
        void UpdateData(string id, string oper, string Col1, string Col2);
      
    }
    [DataContract]
    public class GridListItem
    {
        [DataMember]
        public string Col1 { get; set; }
        [DataMember]
        public string Col2 { get; set; }
    }
    [DataContract]
    public class jqGridModel<T>
    {
        public jqGridModel()
        {
            this.total = 0;
            this.rows = null;
            this.records = 0;
            this.page = 0;
        }
        [DataMember]
        public int total { get; set; }
        [DataMember]
        // this is the property where you store the actual data model
        public IList<T> rows { get; set; }
        [DataMember]
        public int page { get; set; }
        [DataMember]
        public int records { get; set; }
        }
    }
