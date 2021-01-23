    [DataContract]
    class User
    {
        [DataMember(Name = "ID")]
        public string ID;
        /**
         * First name of the User
         */
        [DataMember(Name = "firstname")]
        public string FirstName;
        /**
         * Last name of the User
         */
        [DataMember(Name = "lastname")]
        public string LastName;
        /**
         * The group that the User on
         */
        [DataMember(Name = "group")]  
        public Group Group;
    }
