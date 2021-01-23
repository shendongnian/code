    [DataContract(Name = "", Namespace = "")]
    public class MyDataObject
    {
        [OnDeserialized]
        public void OnDeserialized(StreamingContext context)
        {
            if (MyInts == null) MyInts = new List<int>();
        }
        [DataMember(Name = "NeverNull")]
        public IList<int> MyInts { get; set; }
    }
