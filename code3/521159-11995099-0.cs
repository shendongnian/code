    [DataContract]
    public class UniqueNamedItem
    {
        [DataMember]
        int Id { public get; protected set; }
        [DataMember]
        public string Name { public get; protected set; }
    }
