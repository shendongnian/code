    [DataContract]
        public class MediaCollection
        {
            [DataMember]
            public String id;
            [DataMember]
            public String title;
            [DataMember]
            public Enum itemType;
            [DataMember]
            public String artistId;
            ...etc...
        }
