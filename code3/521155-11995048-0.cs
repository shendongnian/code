    [DataContract]
    public class UniqueNamedItem
    {
        [DataMember]
        public int Id { public get; protected set; }
        [DataMember]
        public string Name { public get; protected set; }
    }
