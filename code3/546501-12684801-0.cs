    [DataContract]
    public class Security
    {
        [DataMember]
        public SecurityType UserProfile { get; set; }
        [DataMember]
        public SecurityType UserInfo { get; set; }
        [DataMember]
        public SecurityType Status { get; set; }
        [DataMember]
        public SecurityType Photo { get; set; }
        [DataMember]
        public SecurityType Video { get; set; }
        [DataMember]
        public SecurityType Comment { get; set; }
        [DataMember]
        public SecurityType ProfilePic { get; set; }
        [DataMember]
        public SecurityType Friends { get; set; }
        [DataMember]
        public SecurityType Tags { get; set; }
    }  
