    // Version 2
    [ProtoContract]
    class Person 
    {
        [ProtoMember(1)]
        private int? ID_v1 {
            get { return null; } // means it won't be serialized
            set { if(value != null) ID = value.ToString(); }
        }
        [ProtoMember(2)]
        public string ID { get; set; }
    }
