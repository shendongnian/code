    [DataContract]
    public class User
    {
        [DataMember]
        public String Login { get; set; }
        [DataMember]
        private String login { get { return this.Login; } set { this.Login = value; } }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        private int id { get { return this.UserId; } set { this.UserId = value; } }
    }
