        [DataContract]
        public class CustomObject
        {
            [DataMember(Name = "Name")]
            public string Name { get; set; }
            [DataMember(Name = "Age")]
            public string Age { get; set; }
            [DataMember(Name = "Parent")]
            public Dictionary<string, object> Parent { get; set; }
        }
