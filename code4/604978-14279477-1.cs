    [DataContract]
    public class FacebookFriendData
    {
        [DataMember(Name = "data")]
        public IEnumerable<Friend> Friends { get; set; }
    }
    [DataContract]
    public class Friend
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
    }
    [DataContract]
    public class FacebookGraphData
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "email")]
        public string Email { get; set; }
        [DataMember(Name = "first_name")]
        public string FirstName { get; set; }
        [DataMember(Name = "last_name")]
        public string LastName { get; set; }
        [DataMember(Name = "link")]
        public Uri Link { get; set; }
        [DataMember(Name = "username")]
        public string Username { get; set; }
        [DataMember(Name = "gender")]
        public string Gender { get; set; }
        [DataMember(Name = "locale")]
        public string Locale { get; set; }
    }
