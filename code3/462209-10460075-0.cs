    [DataContract]
    public class ResultCollection
    {
        [DataMember]
        public Result[] Results { get; set; }
    }
    ...
    var ser = new DataContractJsonSerializer(typeof(ResultCollection));
    var collection = (ResultCollection)ser.ReadObject(str);
    var results = collection.Results;
