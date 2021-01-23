    [DataContract]
    public class ScreenDto
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string  Name { get; set; }
        [DataMember]
        public DateTime DateAdded { get; set; }
    }
