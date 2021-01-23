    [DataContract]
    public class UserData
    {
        [DataMember]
        public string Name { set; get; }
        [DataMember]
        public int ID { set; get; }
        [DataMember]
        public string phoneNumber { set; get; }
        [DataMember]
        public string Course { set; get; }
    }
