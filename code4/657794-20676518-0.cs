        [DataContract]
    class UserInfo :SerializationException
    {
        //  Constructors: 
        public UserInfo() { }
        public UserInfo(String username,String password) {
            Username = username;
            Password = password;
        }
       [DataMember] 
        public String Username
        {
            get;
            set;
        }
       [DataMember] 
        public String Password
        {
            get;
            set;
        }
    } 
