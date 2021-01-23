    [DataContract]
    public class Thing : IThing
    {
        [DataMember]
        public int Id { get; set; }
        public string Name { get; set; }
    }
