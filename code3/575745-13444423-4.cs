    [DataContract(Namespace = "http://SwitchKing.Common/Entities/RESTSimplified/2010/07")]
    public class RESTDataSource
    {
        [DataMember]
        public bool Enabled { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
    [CollectionDataContract(ItemName = "RESTDataSource", Namespace = "http://SwitchKing.Common/Entities/RESTSimplified/2010/07")]
    public class ArrayOfRESTDataSource : List<RESTDataSource>
    {
        public ArrayOfRESTDataSource() { }
        public ArrayOfRESTDataSource(IEnumerable<RESTDataSource> collection) : base(collection) { }
    }
