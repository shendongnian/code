    using System.Runtime.Serialization;
    class Cost
    {
        [DataContract]
        public class Title
        {
            [DataMember]
            public string from { get; set; }
            [DataMember]
            public string to { get; set; }
            [DataMember]
            public string from_zip { get; set; }
            [DataMember]
            public string to_zip { get; set; }
            [DataMember]
            public string from_suburb { get; set; }
            [DataMember]
            public string to_suburb { get; set; }
        }
        [DataContract]
        public class Content
        {
            [DataMember]
            public string company { get; set; }
            [DataMember]
            public string package { get; set; }
            [DataMember]
            public string rate { get; set; }
            [DataMember]
            public string rate_second { get; set; }
            [DataMember]
            public string est_time { get; set; }
            [DataMember]
            public string inclusion { get; set; }
            [DataMember]
            public string exclusion { get; set; }
            [DataMember]
            public string last_update { get; set; }
        }
        [DataContract]
        public class RootObject
        {
            [DataMember]
            public Title title { get; set; }
            [DataMember]
            public List<Content> content { get; set; }
        }
    }
